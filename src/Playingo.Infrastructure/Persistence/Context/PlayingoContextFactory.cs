using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Playingo.Application.Common.Configuration;

namespace Playingo.Infrastructure.Persistence.Context
{
    internal class PlayingoContextFactory : IDesignTimeDbContextFactory<PlayingoContext>
    {
        public PlayingoContext CreateDbContext(string[] args)
        {
            var connectionStrings = GetConnectionString();
            var builder = new DbContextOptionsBuilder<PlayingoContext>();

            builder.UseSqlite(connectionStrings.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(PlayingoContext).GetTypeInfo().Assembly
                        .GetName()
                        .Name));

            return new PlayingoContext(builder.Options);
        }

        private static ConnectionStrings GetConnectionString()
        {
            var configuration = GetConfig();
            var connectionStrings = new ConnectionStrings();
            configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            return connectionStrings;
        }

        private static IConfigurationRoot GetConfig()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var projectPath =
                AppDomain.CurrentDomain.BaseDirectory.Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();
            return configuration;
        }
    }
}