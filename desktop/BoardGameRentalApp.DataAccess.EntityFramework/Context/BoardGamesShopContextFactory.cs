using System;
using System.Reflection;
using BoardGameRentalApp.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Context
{
    internal class BoardGamesShopContextFactory : IDesignTimeDbContextFactory<BoardGamesShopContext>
    {
        public BoardGamesShopContext CreateDbContext(string[] args)
        {
            var connectionStrings = GetConnectionString();
            var builder = new DbContextOptionsBuilder<BoardGamesShopContext>();

            if (connectionStrings.UseSqLite)
                builder.UseSqlite(connectionStrings.SqLite,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(BoardGamesShopContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name));
            else
                builder.UseSqlServer(connectionStrings.SqlServer,
                    migrationsOptions =>
                        migrationsOptions.MigrationsAssembly(typeof(BoardGamesShopContext).GetTypeInfo().Assembly
                            .GetName()
                            .Name));

            return new BoardGamesShopContext(builder.Options);
        }

        private static ConnectionStrings GetConnectionString()
        {
            var configuration = GetConfig();
            var connectionStrings = new ConnectionStrings();
            configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            return connectionStrings;
        }

        public static IConfigurationRoot GetConfig()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var projectPath =
                AppDomain.CurrentDomain.BaseDirectory.Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();
            return configuration;
        }
    }
}