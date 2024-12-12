namespace Presentation.Configurations.Extensions;

public static class VersionConfiguration
{
    public static void ConfigureApiVersion(this IServiceCollection service)
    {
        _ = service.AddApiVersioning(options => { options.AssumeDefaultVersionWhenUnspecified = true; })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}