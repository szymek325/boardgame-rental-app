using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Playingo.Application.BoardGames.Validation;
using Playingo.Application.Clients.Validation;
using Playingo.Application.Common.Helpers;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Common.Validation;
using Playingo.Application.Rentals.Validation;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Playingo.Domain.Rentals;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Playingo.Application.Tests")]

namespace Playingo.Application
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BoardGame>, BoardGameValidator>();
            services.AddTransient<IValidator<Client>, ClientValidator>();
            services.AddTransient<IValidator<Rental>, RentalValidator>();
            services.AddTransient<IValidationMessageBuilder, ValidationMessageBuilder>();

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IMediatorService, MediatorService>();

            return services;
        }
    }
}