using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Application.ViewModel.Payment;

namespace SnackHub.Payment.Application.Interfaces.Payment;

public interface IPaymentService
{
    ResultBase<CustomerVM> GetCustomerByPayment(string id);
    ResultBase<PaymentVM> GetPayment(string id);
}