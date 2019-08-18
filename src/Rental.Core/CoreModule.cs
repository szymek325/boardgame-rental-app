﻿using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.CQRS;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Rental.Core.Tests")]

namespace Rental.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BoardGame>, BoardGameValidator>();
            services.AddTransient<IValidator<Client>, ClientValidator>();
            services.AddTransient<IValidator<GameRental>, RentalValidator>();


            services.AddTransient<IMediatorService, MediatorService>();

            return services;
        }
    }
}