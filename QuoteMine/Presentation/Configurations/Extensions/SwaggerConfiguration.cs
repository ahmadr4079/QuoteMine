using System.Reflection;
using Application.Helpers.Exceptions;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Configurations.Extensions;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection service)
    {
        _ = service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "QuoteMine API",
                Version = $"v{Assembly.GetEntryAssembly()?.GetName().Version?.ToString(3)}"
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath, true);
            c.ExampleFilters();
            c.EnableAnnotations();
        });
        service.AddSwaggerExamplesFromAssemblies(typeof(UnknownExceptionExamples).Assembly);
    }

    public static void UseSwaggerAndUi(this IApplicationBuilder app)
    {
        _ = app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var version in provider.ApiVersionDescriptions)
                c.SwaggerEndpoint($"/swagger/{version.GroupName}/swagger.json", version.GroupName);
            c.DocumentTitle = "QuoteMine";
        });
    }
}