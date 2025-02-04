using FoodHut.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FoodHut.DAL.Contexts;

public class AppDbContext : IdentityDbContext<IdentityUser,IdentityRole,string> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Restaurant> Restaurants { get; set; }      
    public DbSet<Product> Products { get; set; }        
    public DbSet<Category> Categories { get; set; }     
    public DbSet<Review> Reviews { get; set; }          

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
        base.OnModelCreating(builder);
    }
}
