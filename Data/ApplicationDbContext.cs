using BookAVacation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookAVacation.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Authentication.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
