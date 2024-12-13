namespace Presentation.Configurations.Extensions;

public static class EnvironmentExtension
{
    public static bool IsDevelopment(this IWebHostEnvironment environment)
    {
        return environment.EnvironmentName.Equals("Development", StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsStage(this IWebHostEnvironment environment)
    {
        return environment.EnvironmentName.Equals("Stage", StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsProduction(this IWebHostEnvironment environment)
    {
        return environment.EnvironmentName.Equals("Production", StringComparison.OrdinalIgnoreCase);
    }
}