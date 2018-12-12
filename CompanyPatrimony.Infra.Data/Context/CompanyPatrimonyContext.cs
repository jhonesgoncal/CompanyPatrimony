using System.IO;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Infra.Data.Mappings;
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
            modelBuilder.ApplyConfiguration(new PatrimonyMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var config = new ConfigurationBuilder()
        //    //     .SetBasePath(Directory.GetCurrentDirectory())
        //    //     .AddJsonFile("config.json", optional: true, reloadOnChange: true)
        //    //     .Build();

        //    //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-TCKG8E1\SQLEXPRESS;Database=CompanyPatrimony;Trusted_Connection=Yes");
        //}
    }
}