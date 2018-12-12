using CompanyPatrimony.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyPatrimony.Infra.Data.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Patrimony>
    {
        public void Configure(EntityTypeBuilder<Patrimony> builder)
        {
            builder.ToTable("Brand");
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}