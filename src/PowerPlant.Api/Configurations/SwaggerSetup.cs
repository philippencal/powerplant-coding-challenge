using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Builder;

namespace PowerPlant.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("powerplant", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PowerPlant API",
                    Description = "This API is part of a code challenge, and the objective is to calculate how much power each of a multitude of different powerplants need to produce for reach load information given.",
                    Contact = new OpenApiContact { Name = "Philip Pencal", Email = "gpencal@hotmail.com", Url = new Uri("https://www.linkedin.com/in/philip-pencal/") },
                    License = new OpenApiLicense { Name = "GNU GPL V3", Url = new Uri("https://github.com/philipgpencal/powerplant-coding-challenge/blob/master/LICENSE") }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = string.Empty;
                s.DocumentTitle = "PowerPlant API";
                s.InjectStylesheet("./swagger/css/swagger-custom.css");
                s.InjectJavascript("./swagger/js/swagger-custom.js");
                s.SwaggerEndpoint("/docs/powerplant/swagger.json", "PowerPlant API v1.0");
            });
        }
    }
}
