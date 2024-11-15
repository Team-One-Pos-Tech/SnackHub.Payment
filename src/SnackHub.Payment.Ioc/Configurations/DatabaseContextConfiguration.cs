using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Infra.Contexts;

namespace SnackHub.Payment.Ioc.Configurations
{
    public static class DatabaseContextConfiguration
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentContext>(
                context => context.UseSqlite(configuration.GetConnectionString("Default"))
            );
        }
    }
}
