using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Rental.Core.Common.Helpers;
using Rental.Core.Validation;
using Rental.CQS;

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
            services.AddTransient<IValidator<Playingo.Domain.Rentals.Rental>, RentalValidator>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IMediatorService, MediatorService>();

            return services;
        }
    }
}