namespace SnackHub.Payment.Api.Endpoints.Payment
{
    public static class PaymentEndpoint
    {
        // public static void AddPaymentEndpoints(this IEndpointRouteBuilder app, Settings settings)
        // {
        //     var tag = "Payment";
        //     var path = $"{settings.Endpoint.BasePath}/{tag}/{{id}}";
        //     app.MapGet(path, ([FromRoute] string id, [FromServices] IPaymentService service) =>
        //     {
        //         var result = service.GetPayment(id);
        //         if (result.IsSuccess)
        //             return Results.Ok(result);
        //         return Results.BadRequest(result);
        //     }).WithTags(tag)
        //         .WithName("get")
        //         .WithOpenApi();
        // }

        public static void AddPaymentProcessEndpoints(this IEndpointRouteBuilder app)
        {
            var path = "api/payment/v1";
            
            app.MapPost(path, () => { });
            app.MapGet(path, () => { });
            
            // List all transaction from a specific client
            app.MapGet("app.MapGet(api/payment/v1/{clientId:guid}", () => { });
        }
    }
}
