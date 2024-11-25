using Microsoft.AspNetCore.Mvc;
using SnackHub.PaymentService.Application.Contracts;
using SnackHub.PaymentService.Application.Models.Payment;
using SnackHub.PaymentService.Application.Models.Payment.Enums;

namespace SnackHub.PaymentService.Api.Endpoints.Payment
{
    public static class PaymentEndpoint
    {
        public static void AddPaymentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/payment/v1/{transactionState}", async ([FromRoute] TransactionState transactionState,
                    [FromServices] IListPaymentUseCase paymentUseCase) =>
                {
                    try
                    {
                        var listPaymentByStateRequest = new ListPaymentByStateRequest(transactionState);
                        var transactions = await paymentUseCase.ExecuteAsync(listPaymentByStateRequest) ?? [];

                        return Results.Ok(transactions);
                    }
                    catch (Exception exception)
                    {
                        // Yep! Really lazy solution here :)
                        return Results.BadRequest(exception.Message);
                    }
                })
                .WithName("ListPaymentByState")
                .WithOpenApi();

            app.MapPost("api/payment/v1/approve/{transactionId:guid}",
                    async ([FromRoute] Guid transactionId,
                        [FromServices] IPaymentManagerUseCase paymentManagerUseCase) =>
                    {
                        try
                        {
                            var paymentApproveRequest = new PaymentApproveRequest(transactionId);

                            await paymentManagerUseCase.ExecuteAsync(paymentApproveRequest);
                            return Results.Ok();
                        }
                        catch (Exception exception)
                        {
                            // Yep! Really lazy solution here :)
                            return Results.BadRequest(exception.Message);
                        }
                    })
                .WithName("ApproveTransaction")
                .WithOpenApi();

            app.MapPost("api/payment/v1/reject/{transactionId:guid}",
                    async ([FromRoute] Guid transactionId,
                        [FromServices] IPaymentManagerUseCase paymentManagerUseCase) =>
                    {
                        try
                        {
                            var paymentApproveRequest = new PaymentRejectRequest(transactionId);

                            await paymentManagerUseCase.ExecuteAsync(paymentApproveRequest);
                            return Results.Ok();
                        }
                        catch (Exception exception)
                        {
                            // Yep! Really lazy solution here :)
                            return Results.BadRequest(exception.Message);
                        }
                    })
                .WithName("RejectTransaction")
                .WithOpenApi();
        }
    }
}