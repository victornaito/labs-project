using System.Reflection;
using labs;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class LabContext : DbContext
    {
        public LabContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Startup)));
        }
    }
}