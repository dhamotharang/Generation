using Microsoft.EntityFrameworkCore;

namespace GenerationFactory.DataProviders
{
    public partial class GenerationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(FrameworkSetting.GenerationSetting.ConnectionString);
            }
        }
    }
}
