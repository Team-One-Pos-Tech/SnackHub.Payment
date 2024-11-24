using System.Collections.Generic;
using System.Threading.Tasks;
using SnackHub.Payment.Application.Models.Payment;

namespace SnackHub.Payment.Application.Contracts;

public interface IListPaymentUseCase
{
    Task<IEnumerable<PaymentTransactionResponse>?> ExecuteAsync(ListPaymentByStateRequest listPaymentByStateRequest);
}