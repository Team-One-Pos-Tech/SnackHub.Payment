using System;
using SnackHub.PaymentService.Application.Models.Payment.Enums;

namespace SnackHub.PaymentService.Application.Models.Payment;

public record PaymentTransactionResponse
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public decimal Amount { get; init; }
    public Guid ClientId { get; init; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    public TransactionState Status { get; init; }
}