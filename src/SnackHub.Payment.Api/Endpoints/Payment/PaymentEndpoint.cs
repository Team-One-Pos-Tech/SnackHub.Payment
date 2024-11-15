using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SnackHub.Payment.Application.Interfaces.Payment;
using SnackHub.Payment.Domain;

namespace SnackHub.Payment.Api.Endpoints.Payment
{
    public static class PaymentEndpoint
    {
        public static void AddPaymentEndpoints(this IEndpointRouteBuilder app, Settings settings)
        {
            var tag = "Payment";
            var path = $"{settings.Endpoint.BasePath}/{tag}/{{id}}";
            app.MapGet(path, ([FromRoute] string id, [FromServices] IPaymentService service) =>
            {
                var result = service.GetPayment(id);
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.BadRequest(result);
            }).WithTags(tag)
                .WithName("get")
                .WithOpenApi();
        }
    }
}
