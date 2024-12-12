using Application;

namespace Presentation.Configurations.Extensions;

public static class EnvironmentConfiguration
{
    public static void ConfigureEnvironment(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(AppSettings.Prefix));
    }
}