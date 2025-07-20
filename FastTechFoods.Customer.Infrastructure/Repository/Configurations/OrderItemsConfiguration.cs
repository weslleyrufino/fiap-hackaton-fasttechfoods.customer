using FastTechFoods.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTechFoods.Customer.Infrastructure.Repository.Configurations;
public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER")
               .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.MenuItemId)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired();

        builder.Property(x => x.OrderId)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired();

        builder.Property(x => x.Quantity)
               .HasColumnType("INT")
               .IsRequired();

        builder.Property(x => x.UnitPrice)
               .HasColumnType("DECIMAL(10,2)")
               .IsRequired();

        builder.Ignore(x => x.Total); // calculado em memória

        // Relacionamento com Order (1:N)
        builder.HasOne(x => x.Order)
               .WithMany(o => o.Items)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com MenuItem (N:1)
        builder.HasOne<MenuItem>()
               .WithMany()
               .HasForeignKey(x => x.MenuItemId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

