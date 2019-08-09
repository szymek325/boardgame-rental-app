using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rental.Core.MediatR;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

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