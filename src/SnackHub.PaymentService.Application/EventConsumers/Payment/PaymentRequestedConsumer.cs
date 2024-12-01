using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using SnackHub.PaymentService.Application.Models.Payment;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Entities;

namespace SnackHub.PaymentService.Application.EventConsumers.Payment;

public class PaymentRequestedConsumer : IConsumer<PaymentRequested>
{
    private readonly ILogger<PaymentRequestedConsumer> _logger;
    private readonly ITransactionRepository _transactionRepository;

    public PaymentRequestedConsumer(
        ILogger<PaymentRequestedConsumer> logger,
        ITransactionRepository transactionRepository)
    {
        _logger = logger;
        _transactionRepository = transactionRepository;
    }

    public async Task Consume(ConsumeContext<PaymentRequested> context)
    {
        // Should have any kind of validation here ?
        var paymentTransaction = PaymentTransaction.Create(
            context.Message.OrderId,
            context.Message.CustomerId,
            context.Message.Amount);

        await _transactionRepository.CreateAsync(paymentTransaction);
    }
}