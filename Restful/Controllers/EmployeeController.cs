using EmployeeFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Restful.Controllers
{
    [Authorize]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManager employeeManager = new EmployeeManager();

        [HttpPost]
        [Route("get")]
        public IActionResult GetDetail(Guid detailId)
        {
            // Check permission
            // TODO

            object result = employeeManager.GetDetail(Guid.Empty, detailId);
            return Ok(result);
        }
    }
}
