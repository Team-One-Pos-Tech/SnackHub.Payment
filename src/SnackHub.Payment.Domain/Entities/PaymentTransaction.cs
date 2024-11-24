using System;
using System.Transactions;

namespace SnackHub.Payment.Domain.Entities;

public record PaymentTransaction
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public decimal Value { get; init; }
    public Guid ClientId { get; init; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    
    public TransactionStatus Status { get; init; }
    
}