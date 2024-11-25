using System.Collections.Generic;
using System.Threading.Tasks;
using SnackHub.PaymentService.Application.Models.Payment;

namespace SnackHub.PaymentService.Application.Contracts;

public interface IListPaymentUseCase
{
    Task<IEnumerable<PaymentTransactionResponse>?> ExecuteAsync(ListPaymentByStateRequest listPaymentByStateRequest);
}