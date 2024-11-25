using System;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Domain.Entities;

public class PaymentTransaction
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public decimal Amount { get; init; }
    public Guid? ClientId { get; init; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    
    public PaymentTransactionState Status { get; set; }

    public static PaymentTransaction Create(Guid orderId, Guid? clientId, decimal amount)
        => new PaymentTransaction
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            ClientId = clientId,
            Amount = amount,

            Status = PaymentTransactionState.Accepted,
            CreatedAt = DateTime.UtcNow
        };

}