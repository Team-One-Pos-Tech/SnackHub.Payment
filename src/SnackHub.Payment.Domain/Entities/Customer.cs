using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Domain.Entities;

public class Customer : Entity<Guid>, IAggregateRoot
{
    public string? CustomerRefID { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
}