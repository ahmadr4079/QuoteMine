using Infrastructure.Helpers.Mapping;
using Mapster;
using MapsterMapper;
using Presentation.Helpers.Mapping;

namespace Presentation.Configurations.Extensions;

public static class MapsterRegistration
{
    public static IServiceCollection ConfigureMapster(this IServiceCollection service)
    {
        var config = new TypeAdapterConfig();

        var assemblies = new[]
        {
            typeof(MappingPresentation).Assembly,
            typeof(MappingInfrastructure).Assembly
        };
        config.Scan(assemblies);
        service.AddSingleton(config);
        service.AddSingleton<IMapper, ServiceMapper>();
        return service;
    }
}