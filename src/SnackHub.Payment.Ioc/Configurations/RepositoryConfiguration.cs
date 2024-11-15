using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Infra.GatewayPayment;
using SnackHub.Payment.Infra.interfaces;
using SnackHub.Payment.Infra.Repositories;

namespace SnackHub.Payment.Ioc.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IGatewayPayment, MercagoPagaGateway>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
