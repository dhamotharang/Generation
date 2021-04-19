using Common;
using Common.Responses;
using FrameworkSetting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restful.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var isExist = await userManager.FindByNameAsync(model.Username);
            if (isExist != null)
            {
                return Ok(new ResponseOutput<object>(null, NotificationType.Error, GenerationStatusCode.InternalServerError, GenerationResource.MSG_001, null));
            }
            else
            {
                ApplicationUser user = new()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var data = await userManager.CreateAsync(user, model.Password);
                if (!data.Succeeded)
                {
                    return Ok(new ResponseOutput<object>(null, NotificationType.Error, GenerationStatusCode.InternalServerError, GenerationResource.MSG_002, null));
                }
                else
                {
                    return Ok(new ResponseOutput<object>(null, NotificationType.Success, GenerationStatusCode.Ok, GenerationResource.MSG_003, null));
                }
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssued"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return Ok(new ResponseOutput<object>(new { _id = user.Id, token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo }, 
                    NotificationType.Success, GenerationStatusCode.Ok, GenerationResource.MSG_004, null));
            }

            return Unauthorized();
        }
    }
}
