using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Domain;

namespace SnackHub.Payment.Api.Endpoints;

public static class CustomerEndpoint
{
    public static void AddCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var tag = "Customer";
        app.MapGet("/", ([FromServices] ConfiguracaoApp options, [FromServices] IPaymentService service) =>
            {
                return service.GetCustomerByPayment(1);
            }).WithTags(tag)
            .WithName("helloworld")
            .WithOpenApi();
    }
}