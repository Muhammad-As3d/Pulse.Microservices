using Carter;
using Mapster;
using MapsterMapper;
using BuildingBlocks.Extensions;
using Microsoft.EntityFrameworkCore;
using NotificationService.Implementations;
using NotificationService.Implementations.Services;
using NotificationService.Interfaces;
using NotificationService.Interfaces.Services;
using NotificationService.Persistence;

namespace NotificationService;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddOpenApi();
        services.AddCarter();
        services.AddAuthenticationConfiguration(configuration);
        services.AddAuthorization();
        services.AddHttpContextAccessor();

        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        var mappingConfiguration = TypeAdapterConfig.GlobalSettings;
        mappingConfiguration.Scan(assembly);

        services.AddSingleton<IMapper>(new Mapper(mappingConfiguration));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICurrentUser, CurrentUser>();

        return services;
    }

}
