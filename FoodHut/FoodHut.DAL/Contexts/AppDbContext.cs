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
    public DbSet<WorkSchedule> WorkSchedules { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "e6eb5f0a-6258-48e9-8fce-cc2572049bf6", Name = "Admin", NormalizedName = "ADMIN"},
            new IdentityRole { Id = "8cf89746-f001-4af7-92dc-4e71a02a42f9", Name = "User", NormalizedName = "USER" }
        );
        #endregion


        #region User
        IdentityUser admin = new()
        {
            Id = "abc63b97-f14a-4601-8dc6-9d0583e118cf",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, "admin123");


        builder.Entity<IdentityUser>().HasData(admin);


        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "e6eb5f0a-6258-48e9-8fce-cc2572049bf6" }
        );
        #endregion


        #region Settings
        builder.Entity<Setting>(b =>
        {
            b.HasData(
                new Setting
                {
                    Id = 1,
                    Address = "12345 Fake ST NoWhere, AB Country",
                    Phone = "(123) 456-7890",
                    Email = "info@website.com",
                    GoogleMapApiKey = "https://maps.googleapis.com/maps/api/js?key=AIzaSyCtme10pzgKSPeJVJrG1O3tjR6lk98o4w8&callback=initMap"
                });
        });
        #endregion

        base.OnModelCreating(builder);
    }
}
