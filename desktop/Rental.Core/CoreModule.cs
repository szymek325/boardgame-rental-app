using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Rental.Core.Common;

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