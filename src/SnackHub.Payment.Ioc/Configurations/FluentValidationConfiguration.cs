using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Mappers.CustomeMapper;
using SnackHub.Payment.Application.Validations.Customer;

namespace SnackHub.Payment.Ioc.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CustomerValidation>();
        }
    }
}
