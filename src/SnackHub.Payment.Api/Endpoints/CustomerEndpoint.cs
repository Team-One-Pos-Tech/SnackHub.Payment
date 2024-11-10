namespace SnackHub.Payment.Api.Endpoints;

public static class CustomerEndpoint
{
    public static void AddCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var tag = "Customer";
        app.MapGet("/", () =>
            {
                return "olá mundo";
            }).WithTags(tag)
            .WithName("helloworld")
            .WithOpenApi();
    }
}