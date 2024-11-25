using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using SnackHub.PaymentService.Application.Contracts;
using SnackHub.PaymentService.Application.Models.Payment;
using SnackHub.PaymentService.Application.Models.Payment.Enums;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Application.UseCases;

public class PaymentManagerUseCase : IPaymentManagerUseCase
{
    
    private readonly ILogger<PaymentManagerUseCase> _logger;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public PaymentManagerUseCase(
        ILogger<PaymentManagerUseCase> logger, 
        ITransactionRepository transactionRepository, 
        IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _transactionRepository = transactionRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task ExecuteAsync(PaymentApproveRequest paymentApproveRequest)
    {
        _logger.LogInformation("Approving Transaction with id: {TransactionId}", paymentApproveRequest.TransactionId);
        await ProcessPaymentAsync(paymentApproveRequest.TransactionId, PaymentTransactionState.Approved);
    }

    public async Task ExecuteAsync(PaymentRejectRequest paymentRejectRequest)
    {
        _logger.LogInformation("Rejecting Transaction with id: {TransactionId}", paymentRejectRequest.TransactionId);
        await ProcessPaymentAsync(paymentRejectRequest.TransactionId, PaymentTransactionState.Rejected);
    }

    private async Task ProcessPaymentAsync(Guid transactionId, PaymentTransactionState nextState)
    {
        var transaction = await _transactionRepository.GetByIdAsync(transactionId);
        if (transaction is null)
        {
            _logger.LogError("Transaction with id: {TransactionId} not found", transactionId);
            throw new InvalidOperationException($"Transaction with id: {transactionId} not found");
        }
        
        transaction.Status = nextState;
        await _transactionRepository.EditAsync(transaction);
        
        var paymentStatusUpdated = new PaymentStatusUpdated(transaction.OrderId, transaction.Id, (TransactionState)transaction.Status);
        await _publishEndpoint.Publish(paymentStatusUpdated);
    }
}