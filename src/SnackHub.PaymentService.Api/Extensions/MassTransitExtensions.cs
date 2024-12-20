using MassTransit;
using SnackHub.PaymentService.Api.Configuratinon;
using SnackHub.PaymentService.Application.EventConsumers.Client;
using SnackHub.PaymentService.Application.EventConsumers.Payment;

namespace SnackHub.PaymentService.Api.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransit(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var settings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();
        
        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("payment-service"));
            
            busConfigurator.AddConsumer<ClientCreatedConsumer>();
            busConfigurator.AddConsumer<PaymentRequestedConsumer>();
            
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