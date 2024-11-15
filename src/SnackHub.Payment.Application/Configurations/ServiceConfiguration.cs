using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackHub.Payment.Application.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
