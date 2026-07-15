using BuildingBlocks.Behaviors;
using BuildingBlocks.Extensions;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Implementations;
using ProgressTrackingService.Implementations.Services;
using ProgressTrackingService.Interfaces;
using ProgressTrackingService.Interfaces.Services;
using ProgressTrackingService.Persistence;

namespace ProgressTrackingService;

public static class DependencyInjection
{
    public static IServiceCollection AddProgressTrackingDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddOpenApi();
        services.AddAuthenticationConfiguration(configuration);

        services.AddScoped<IUnitOfWork, UnitOFWork>();
        services.AddScoped<ICurrentUser, CurrentUser>();

        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddBehavior(typeof(ValidationBehavior<,>));
        });

        //services.AddMassTransitWithRabbitMq(configuration, cfg =>
        //{
        //    //cfg.AddConsumersFromNamespaceContaining<Program>();
        //});

        return services;
    }
}
