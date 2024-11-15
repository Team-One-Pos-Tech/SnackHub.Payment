using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Infra.interfaces;

public interface IGatewayPayment
{

    Customer CreateCustomer(Customer customer);
    List<Customer> ListCustomers();
    Domain.Entities.Payment PaymentCreate(Domain.Entities.Payment input);
    Domain.Entities.Payment GetPayment(string id);
}