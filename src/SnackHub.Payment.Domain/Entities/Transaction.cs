using SnackHub.Payment.Domain.Enums;

namespace SnackHub.Payment.Domain.Entities;

public class Transaction : Entity<Guid>
{
    public required string AuthorizationCode { get; set; }
    public string CardBrand { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal TotalValue { get; set; }
    public decimal TransactionCost { get; set; }
    public StatusTransaction Status { get; set; }
    public string TID { get; set; } // Id
    public string NSU { get; set; } // Meio (paypal)
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }
}