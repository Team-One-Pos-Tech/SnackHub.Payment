using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnackHub.Payment.Application.Interfaces.Customer;
using SnackHub.Payment.Application.Interfaces.Payment;
using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Domain;

namespace SnackHub.Payment.Api.Endpoints.Customer;

public static class CustomerEndpoint
{
    public static void AddCustomerEndpoints(this IEndpointRouteBuilder app, Settings settings)
    {
        var tag = "Customer";
        var path = $"{settings.Endpoint.BasePath}/{tag}";

        app.MapGet($"{path}/Payment/{{paymentID}}", ([FromRoute] string paymentID, [FromServices] IPaymentService service) =>
            {
                var result = service.GetCustomerByPayment(paymentID);
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.BadRequest(result);
            }).WithTags(tag)
            .WithName("getbaypaymentID")
            .WithOpenApi();

        app.MapPost(path, ([FromBody] CustomerInput input, [FromServices] ICustomerService service) =>
        {
            var result = service.CreateCustomer(input);
            if (result.IsSuccess)
                return Results.Ok(result);
            return Results.BadRequest(result);
        }).WithTags(tag)
            .WithName("createcustomer")
            .WithOpenApi();

        app.MapPut($"{path}/{{id}}", ([FromRoute] Guid id, [FromBody] CustomerInput input, [FromServices] ICustomerService service) =>
        {
            var result = service.UpdateCustomer(input, id);
            if (result.IsSuccess)
                return Results.Ok(result);
            return Results.BadRequest(result);
        }).WithTags(tag)
            .WithName("updatecustomer")
            .WithOpenApi();
    }
}