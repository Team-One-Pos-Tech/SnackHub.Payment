using System.Threading.Tasks;
using SnackHub.Payment.Application.Models.Payment;

namespace SnackHub.Payment.Application.Contracts;

public interface IPaymentManagerUseCase
{
    Task ExecuteAsync(PaymentApproveRequest paymentApproveRequest);
    Task ExecuteAsync(PaymentRejectRequest paymentRejectRequest);
}