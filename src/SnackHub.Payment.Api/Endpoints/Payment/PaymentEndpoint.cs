using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Domain;

namespace SnackHub.Payment.Api.Endpoints.Payment
{
    public static class PaymentEndpoint
    {
        public static void AddPaymentEndpoints(this IEndpointRouteBuilder app)
        {
            var tag = "Payment";
            var path = $"api/v1/{tag}/{{id}}";
            app.MapGet(path, ([FromRoute] string id, [FromServices] Settings options, [FromServices] IPaymentService service) =>
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
