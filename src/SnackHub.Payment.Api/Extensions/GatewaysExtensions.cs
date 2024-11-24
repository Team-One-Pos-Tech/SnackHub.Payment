using Refit;
using SnackHub.Payment.Api.Configuratinon;
using SnackHub.Payment.Infra.Gateways.MercadoPago.Abstractions;

namespace SnackHub.Payment.Api.Extensions;

public static class GatewaysExtensions
{
    public static IServiceCollection AddAcquiringBankApiGateway(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var settings = configuration.GetSection("ApiGateway").Get<ApiGatewaySettings>();
        serviceCollection
            .AddRefitClient<IMercadoPagoGateway>()
            .ConfigureHttpClient(px => px.BaseAddress = new Uri(settings.MercadoPagoEndpoint));

        return serviceCollection;
    }
}