using System.IO;
using AutoMapper;
using CompanyPatrimony.Infra.CrossCutting.IoC;
using CompanyPatrimony.Infra.Data.Context;
using CompanyPatrimony.Service.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyPatrimony.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           

            Configuration = configuration;
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CompanyPatrimonyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //AutoMapperConfiguration.RegisterMappings();
            services.AddMvc();
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper();

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
