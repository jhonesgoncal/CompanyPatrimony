using System.IO;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Infra.Data.Mappings;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyPatrimony.Infra.Data.Context
{
    public class CompanyPatrimonyContext : DbContext
    {
        public CompanyPatrimonyContext(DbContextOptions<CompanyPatrimonyContext> options)
            : base(options) { }
        public CompanyPatrimonyContext() { }

        public DbSet<Patrimony> Patrimonies { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new PatrimonyMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
             
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}