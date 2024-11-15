using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SnackHub.Payment.Ioc;

public static class Main
{
    public static void AddMainProject(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddAppDependencyInjection(configuration);
    }
}