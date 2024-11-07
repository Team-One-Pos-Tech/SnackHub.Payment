namespace SnackHub.Payment.Domain.Entities;

public class Product : Entity<Guid>
{
    public required string ReferenceId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
}