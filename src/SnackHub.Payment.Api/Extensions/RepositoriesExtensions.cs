using Microsoft.EntityFrameworkCore;
using SnackHub.Payment.Domain.Contracts;
using SnackHub.Payment.Infra.Repositories;
using SnackHub.Payment.Infra.Repositories.Contexts;
using SnackHub.Production.Api.Configuration;

namespace SnackHub.Payment.Api.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        // serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        serviceCollection
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IClientRepository, ClientRepository>();
        
        return serviceCollection;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var settings = configuration.GetSection("Storage:PostgreSQL").Get<PostgreSQLSettings>();
        var connectionString = $"Host={settings.Host};Username={settings.UserName};Password={settings.Password};Database={settings.Database}";
        
        serviceCollection
            .AddDbContext<PaymentContext>(options => 
                options.UseNpgsql(connectionString));

        return serviceCollection;
    }
}