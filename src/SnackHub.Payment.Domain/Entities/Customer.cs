using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Domain.Entities;

public class Customer : Entity<Guid>, IAggregateRoot
{
    public string? CustomerRefID { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public Address? DefaultAddress { get; set; }
    public List<Address> Addresses { get; set; } = Enumerable.Empty<Address>().ToList();
}