using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Playingo.Application.Common.Configuration;
using Playingo.Application.Common.Interfaces;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Repositories;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Playingo.Infrastructure.Tests")]

namespace Playingo.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<PlayingoContext>(options => options.UseSqlite(connectionStrings.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(PlayingoContext).GetTypeInfo().Assembly
                        .GetName()
                        .Name)));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}