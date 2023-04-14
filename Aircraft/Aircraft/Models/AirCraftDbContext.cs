using System;
using Microsoft.EntityFrameworkCore;

namespace Aircraft.Models
{
    public class AirCarftDbContext : DbContext
    {
        public AirCarftDbContext(DbContextOptions<AirCarftDbContext> options) : base(options)
        {

        }

        public DbSet<AirCraft> AirCraft { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=lbs; User Id=sa; password=123; TrustServerCertificate= True");
        }
    }
}

