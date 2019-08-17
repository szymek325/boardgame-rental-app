using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Rental.CQRS;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Rental.Core.Tests")]

namespace Rental.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IMediatorService, MediatorService>();

            return services;
        }
    }
}