﻿using System.Reflection;
using System.Runtime.CompilerServices;
using BoardGameRentalApp.Core.Configuration;
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
        public static IServiceCollection AddEntityFrameworkModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<BoardGameRentalContext>(options => options.UseSqlServer(connectionStrings.MainDb,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(BoardGameRentalContext).GetTypeInfo().Assembly.GetName().Name)));

            //created only by unit of work so should not be registered in DI
            //services.AddTransient<IBoardGamesRepository, BoardGamesRepository>();
            //services.AddTransient<IClientsRepository, ClientsRepository>();
            //services.AddTransient<IGameRentalsRepository, GameRentalsRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}