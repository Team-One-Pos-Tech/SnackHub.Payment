namespace SnackHub.Payment.Domain.Entities;

public class Sale : Entity<Guid>
{
    public DateTime SaleDate { get; set; }
    public Decimal TotalAmount { get; set; }
    public string? CustomerId { get; set; }
    public Guid PaymentId { get; set; }
    public Payment? Payment { get; set; }
}