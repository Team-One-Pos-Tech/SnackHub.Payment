namespace SnackHub.Payment.Application.ViewModel.Customer;

public class CustomerVM
{
    public Guid Id { get; private set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
}