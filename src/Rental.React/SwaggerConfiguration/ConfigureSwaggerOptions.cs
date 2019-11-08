using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rental.React.SwaggerConfiguration
{
    internal class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = $"Rental Web API {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = "Boardgame rental shop web api",
                        Contact = new OpenApiContact
                        {
                            Name = "Mateusz Szymkowiak",
                            Email = "matszym325@gmail.com"
                        }
                    });
            //options.IncludeXmlComments(Path.Combine(
            //    XmlDocumentationHelper.GetDocumentationPath(Assembly.GetExecutingAssembly().GetName().Name)));
        }

        public static class XmlDocumentationHelper
        {
            private const string TestProjectNaming = ".Tests";

            public static string GetDocumentationPath(string webApiAssemblyName)
            {
                var baseDirectory = AppContext.BaseDirectory;
                if (!baseDirectory.Contains(".Tests"))
                    baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Split(new string[1]
                    {
                        "bin\\"
                    }, StringSplitOptions.None)[0];
                return Path.Combine(baseDirectory, webApiAssemblyName + ".xml");
            }
        }
    }
}