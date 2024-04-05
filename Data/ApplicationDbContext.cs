using BookAVacation.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAVacation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            Console.WriteLine("success");
        }
    }
}
