using System;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Domain.Entities;

public record PaymentTransaction
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public decimal Amount { get; init; }
    public Guid ClientId { get; init; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    
    public PaymentTransactionState Status { get; set; }
    
}