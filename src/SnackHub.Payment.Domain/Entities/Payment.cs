using SnackHub.Payment.Domain.Enums;
using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Domain.Entities;

public class Payment : Entity<Guid>, IAggregateRoot
{
    public Gateway Gatway { get; set; }
    public string? GatewayRefID { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateApproved { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public Customer? Customer { get; set; }
    public CreditCard? CreditCard { get; set; }

    // EF Relation
    public List<Transaction> Transactions { get; set; } = Enumerable.Empty<Transaction>().ToList();

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
}