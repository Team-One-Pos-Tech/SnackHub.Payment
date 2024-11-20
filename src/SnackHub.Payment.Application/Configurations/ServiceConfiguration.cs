using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Interfaces.Customer;
using SnackHub.Payment.Application.Interfaces.Payment;
using SnackHub.Payment.Application.Services.Customer;
using SnackHub.Payment.Application.Services.Payment;

namespace SnackHub.Payment.Application.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
