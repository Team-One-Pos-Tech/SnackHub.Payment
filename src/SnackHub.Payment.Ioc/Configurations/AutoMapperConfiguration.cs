using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Application.Mappers.CustomeMapper;

namespace SnackHub.Payment.Ioc.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerProfile));
        }
    }
}
