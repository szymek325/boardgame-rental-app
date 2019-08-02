using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rental.Core.Configuration;
using Rental.Core.Interfaces.DataAccess;
using Rental.DataAccess.Context;
using Rental.DataAccess.Repositories;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Rental.DataAccess
{
    public static class EntityFrameworkModule
    {
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<RentalContext>(options => options.UseSqlite(connectionStrings.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(RentalContext).GetTypeInfo().Assembly
                        .GetName()
                        .Name)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}