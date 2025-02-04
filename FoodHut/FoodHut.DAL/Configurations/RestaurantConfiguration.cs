﻿using FoodHut.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodHut.DAL.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.Restaurant)  
            .HasForeignKey(x => x.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);


        builder
            .Property(e => e.Name)
            .HasMaxLength(70)
            .IsRequired();


        builder
            .Property(e => e.Location)
            .HasMaxLength(120)
            .IsRequired();
    }
}
