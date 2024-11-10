using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Application.Services;

namespace SnackHub.Payment.Ioc;

public static class DependencyInjection
{
    public static void AddAppDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
    }
}