using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.CrossCutting.DependencyInjector;
using AspNetCore.CrossCutting.Mappings;
using AspNetCore.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AspNetCore.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureContext.ConfigureDependencyInjector(services);
            ConfigureRepository.ConfigureDependencyInjector(services);
            ConfigureService.ConfigureDependencyInjector(services);
            ConfigureSecurity.ConfigureJwtToken(services, Configuration);

            ConfigureSwagger(services);
            ConfigureMapping(services);

            services.AddControllers();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(opt => {
                opt.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "AspNetCore 3.1",
                    Description = "Exemplo de API ASP.NET Core 3.1",
                    Contact = new OpenApiContact {
                        Name = "Jô Araújo",
                        Url = new Uri("https://github.com/joasimonson/AspNetCore")
                    }
                });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new string[] {}
                    }
                });
            });
        }

        private void ConfigureMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(DTOToModelProfile));
                cfg.AddProfile(typeof(EntityToDTOProfile));
                cfg.AddProfile(typeof(ModelToEntityProfile));
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.RoutePrefix = string.Empty;
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCore 3.1");
            });

            var options = new RewriteOptions();
            options.AddRedirect("^$", "swagger");
            app.UseRewriter(options);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
