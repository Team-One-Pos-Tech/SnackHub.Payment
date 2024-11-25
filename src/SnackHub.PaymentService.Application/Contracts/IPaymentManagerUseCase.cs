using System.Threading.Tasks;
using SnackHub.PaymentService.Application.Models.Payment;

namespace SnackHub.PaymentService.Application.Contracts;

public interface IPaymentManagerUseCase
{
    Task ExecuteAsync(PaymentApproveRequest paymentApproveRequest);
    Task ExecuteAsync(PaymentRejectRequest paymentRejectRequest);
}