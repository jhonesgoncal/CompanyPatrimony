using CompanyPatrimony.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyPatrimony.Infra.Data.Mappings
{
    public class PatrimonyMap : IEntityTypeConfiguration<Patrimony>
    {
        public void Configure(EntityTypeBuilder<Patrimony> builder)
        {
            builder.ToTable("Patrimony");
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder
                .Property(p => p.NumberTumble)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Ignore(p => p.Notifications);
            builder
                .Ignore(p => p.Invalid);
            builder
                .Ignore(p => p.Valid);

            builder
                .HasOne(p => p.Brand)
                .WithMany(b => b.Patrimonies)
                .HasForeignKey(p => p.BrandId);
        }
    }
}