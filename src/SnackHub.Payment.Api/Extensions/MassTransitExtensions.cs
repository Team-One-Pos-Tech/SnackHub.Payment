using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnackHub.Payment.Api.Configuratinon;
using SnackHub.Payment.Application.EventConsumers.Client;

namespace SnackHub.Payment.Api.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransit(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var settings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();
        
        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("payment-service"));
            
            busConfigurator.AddConsumer<ClientCreatedConsumer>();
            
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(settings.Host, "/",  rabbitMqHostConfigurator =>
                {
                    rabbitMqHostConfigurator.Username(settings.UserName);
                    rabbitMqHostConfigurator.Password(settings.Password);							
                });
                
                configurator.AutoDelete = true;
                configurator.ConfigureEndpoints(context);
            });
            
        });
        
        return serviceCollection;
    }
}