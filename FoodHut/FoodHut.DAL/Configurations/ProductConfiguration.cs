using FoodHut.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodHut.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder
            .Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .HasMaxLength(70)
            .IsRequired();

        builder
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
