using Microsoft.EntityFrameworkCore;

namespace EmployeeFactory.DataProviders
{
    public partial class EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(FrameworkSetting.GenerationSetting.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.Property(e => e.FullName).HasMaxLength(255).IsUnicode(true).IsRequired(false);
                e.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).IsRequired(false);
                e.Property(e => e.Skyped).HasMaxLength(150).IsUnicode(false).IsRequired(false);
            });
        }
    }
}
