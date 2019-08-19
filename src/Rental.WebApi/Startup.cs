using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rental.Core;
using Rental.Core.Common.Configuration;
using Rental.DataAccess;
using Rental.WebApi.Middleware;

namespace Rental.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup), typeof(CoreModule), typeof(EntityFrameworkModule));
            services.AddMediatR(typeof(Startup), typeof(CoreModule), typeof(EntityFrameworkModule));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo()); });

            var connectionStrings = new ConnectionStrings();
            Configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            services.AddCoreModule();
            services.AddDataAccessModule(connectionStrings);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();
                    var error = new ErrorDetails
                    {
                        Guid = Guid.NewGuid(),
                        ExceptionType = exceptionHandlerPathFeature.Error.GetType().Name,
                        Message = exceptionHandlerPathFeature.Error.Message
                    };
                    await context.Response.WriteAsync(error.ToString());
                });
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}