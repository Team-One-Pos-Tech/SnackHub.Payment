using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Infra.interfaces;

public interface IGatewayPayment
{
    Customer CreateCustomer(Customer customer);
    List<Customer> ListCustomers();
}