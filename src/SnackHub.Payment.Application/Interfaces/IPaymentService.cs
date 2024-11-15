using SnackHub.Payment.Application.ViewModel;

namespace SnackHub.Payment.Application.Interfaces;

public interface IPaymentService
{
    ResultBase<CustomerVM> GetCustomerByPayment(string id);
    ResultBase<PaymentVM> GetPayment(string id);
}