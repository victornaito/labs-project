using Microsoft.EntityFrameworkCore;

namespace labs
{
    public class LabContext : DbContext
    {
        public LabContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}