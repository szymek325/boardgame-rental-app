using System.Reflection;
using System.Runtime.CompilerServices;
using BoardGameRentalApp.Common.Configuration;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using BoardGameRentalApp.DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.DataAccess.EntityFramework
{
    public static class EntityFrameworkModule
    {
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            if (connectionStrings.UseSqLite)
                services.AddDbContext<BoardGamesShopContext>(options => options.UseSqlite(connectionStrings.SqLite,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(BoardGamesShopContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name)));
            else
                services.AddDbContext<BoardGamesShopContext>(options => options.UseSqlServer(
                    connectionStrings.SqlServer,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(BoardGamesShopContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name)));


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}