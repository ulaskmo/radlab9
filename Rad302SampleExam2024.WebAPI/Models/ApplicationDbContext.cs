using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rad302SampleExam2024.WebAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            // Seeding to be done in Seeder after we add the context
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Rad302SampleExam2025DB-ppowell";
            optionsBuilder.UseSqlServer(myconnectionstring);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
