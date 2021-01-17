using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MosarticoApi.Application.Mapping;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using MosarticoApi.Infrastruture.CrossCutting.IOC;

namespace MosarticoApi
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
            services.AddDbContext<MosarticoContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<MosarticoContext>(x => x.UseInMemoryDatabase("InMemoryProvider"));
            services.AddAutoMapper(new[] { typeof(MappingEntities).Assembly });
            services.AddCors();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mosartico API",
                    Description = @"MosarticoApi para integração com o app mobile. Projeto hackathon CCR 2021<br><br>
                                    Time 220 integrantes:<br><br>
                                    <a href='https://www.linkedin.com/in/lucas-fernandes-92a1bb157/' target='_blank'>Lucas Fernandes - Backend</a><br>
                                    <a href='https://www.linkedin.com/in/apolo-rossi-13458656/' target='_blank'>Apolo Rossi - FrontEnd</a><br>
                                    <a href='https://www.linkedin.com/in/cleyton-gon%C3%A7alves-98a845108/' target='_blank'>Cleyton Willian - RH</a><br>
                                    <a href='https://www.linkedin.com/in/danilo-muniz/' target='_blank'>Danilo Muniz - Business</a><br>
                                    <a href='https://www.linkedin.com/in/gabriela-cavalcanti-47727a161/' target='_blank'>Gabriela Cavalcanti - UX</a><br>
                                    <a href='https://www.linkedin.com/in/thays-moraes-de-almeida-214934190/' target='_blank'>Thays Moraes - Educação</a>"
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ModuleIOC());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mosartico API");
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
