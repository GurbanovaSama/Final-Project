using FluentValidation;
using FluentValidation.AspNetCore;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using FoodHut.BL.Utilities;
using FoodHut.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FoodHut.BL;

public static class ConfigurationServices
{
    public static void AddBLService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();


        services.AddScoped<IAccountService, AccountService>();  
        services.AddScoped<IWorkScheduleService, WorkScheduleService>();    
        services.AddScoped<ICategoryService, CategoryService>();    
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<EmailService, EmailService>();       


    }
}
