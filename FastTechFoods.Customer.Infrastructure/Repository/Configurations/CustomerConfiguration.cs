using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTechFoods.Customer.Infrastructure.Repository.Configurations;
internal class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .HasColumnType("UNIQUEIDENTIFIER")
               .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(e => e.Name)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

        builder.Property(e => e.Email)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

        builder.Property(e => e.CPF)
               .HasColumnType("VARCHAR(11)")
               .IsRequired();

        builder.Property(e => e.PasswordHash)
               .HasColumnType("VARCHAR(255)")
               .IsRequired();

        builder.Property(e => e.CreatedAt)
               .HasColumnType("DATETIME")
               .IsRequired();
    }
}
