using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnackHub.Payment.Application.Interfaces.Payment;
using SnackHub.Payment.Domain;

namespace SnackHub.Payment.Api.Endpoints.Customer;

public static class CustomerEndpoint
{
    public static void AddCustomerEndpoints(this IEndpointRouteBuilder app, Settings settings)
    {
        var tag = "Customer";
        var path = $"{settings.Endpoint.BasePath}/{tag}/Payment/{{paymentID}}";
        app.MapGet(path, ([FromRoute] string paymentID, [FromServices] IPaymentService service) =>
            {
                var result = service.GetCustomerByPayment(paymentID);
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.BadRequest(result);
            }).WithTags(tag)
            .WithName(tag)
            .WithOpenApi();
    }
}