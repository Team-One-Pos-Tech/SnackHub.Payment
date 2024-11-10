using Microsoft.Extensions.DependencyInjection;

namespace SnackHub.Payment.Ioc;

public static class Main
{
    public static void AddMainProject(this IServiceCollection services)
    {
        services.AddAppDependencyInjection();
    }
}