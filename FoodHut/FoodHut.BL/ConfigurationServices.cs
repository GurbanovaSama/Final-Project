using FluentValidation;
using FluentValidation.AspNetCore;
using FoodHut.BL.DTOs;
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


    }
}
