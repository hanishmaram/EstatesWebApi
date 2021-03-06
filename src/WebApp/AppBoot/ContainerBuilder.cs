﻿using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApp.DAL;
using WebApp.DAL.DataServices;
using WebApp.Model;
using WebApp.Validators;

namespace WebApp.AppBoot
{
    public static class ContainerBuilder
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>();
            services.AddTransient<IRepository, Repository>();

            services.AddTransient<IDataService<EstateTempDto>, EstatesDataService>();
            services.AddTransient<IValidator<EstateTempDto>, EstateValidator>();

            services.AddTransient<IDataService<ImageDto>, ImageDataService>();
            services.AddTransient<IValidator<IFormFile>, ImageValidator>();
        }
    }
}