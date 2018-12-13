using AutoMapper;
using CompanyPatrimony.Domain.Contracts;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Infra.Data.Context;
using CompanyPatrimony.Infra.Data.Repositories;
using CompanyPatrimony.Infra.Data.UoW;
using CompanyPatrimony.Service.Contracts;
using CompanyPatrimony.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyPatrimony.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPatrimonyService, PatrimonyService>();
            services.AddScoped<IBrandService, BrandService>();

            //Infra - Data
            services.AddScoped<IPatrimonyRepository, PatrimonyRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CompanyPatrimonyContext>();


        }
    }
}