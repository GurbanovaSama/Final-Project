﻿using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;
using FoodHut.DAL.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FoodHut.DAL
{
    public static class ConfigurationServices
    {
        public static void AddDALService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Restaurant>, Repository<Restaurant>>();
            services.AddScoped<IRepository<Review>, Repository<Review>>();
            services.AddScoped<IRepository<WorkSchedule>, Repository<WorkSchedule>>();
            services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
            services.AddScoped<IRepository<Setting>, Repository<Setting>>();
        }
    }
}
