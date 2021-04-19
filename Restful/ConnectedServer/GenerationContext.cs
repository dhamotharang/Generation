using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restful.Models;

namespace Restful.ConnectedServer
{
    public class GenerationContext : IdentityDbContext<ApplicationUser>
    {
        public GenerationContext(DbContextOptions<GenerationContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
