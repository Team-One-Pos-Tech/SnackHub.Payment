using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Configurations;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Application.Services;
using SnackHub.Payment.Ioc.Configurations;

namespace SnackHub.Payment.Ioc;

public static class DependencyInjection
{
    public static void AddAppDependencyInjection(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDatabaseContext(configuration);

        services.AddAutoMapperConfiguration();

        services.AddRepositoryConfigurations();

        services.AddServiceConfiguration();

        services.AddFluentValidation();
    }
}