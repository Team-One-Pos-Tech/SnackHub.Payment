using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.PaymentService.Application.Contracts;
using SnackHub.PaymentService.Application.Models.Payment;
using SnackHub.PaymentService.Application.Models.Payment.Enums;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Application.UseCases;

public class ListPaymentUseCase : IListPaymentUseCase
{
    
    private readonly ILogger<ListPaymentUseCase> _logger;
    private readonly ITransactionRepository _transactionRepository;

    public ListPaymentUseCase(
        ILogger<ListPaymentUseCase> logger, 
        ITransactionRepository transactionRepository)
    {
        _logger = logger;
        _transactionRepository = transactionRepository;
    }

    
    public async Task<IEnumerable<PaymentTransactionResponse>?> ExecuteAsync(ListPaymentByStateRequest listPaymentByStateRequest)
    {
        var state = (PaymentTransactionState)listPaymentByStateRequest.State;
        var transactions = await _transactionRepository.ListTransactionsStateAsync(state);

        return transactions
            .Select(paymentTransaction => new PaymentTransactionResponse
            {
                Id = paymentTransaction.Id,
                OrderId = paymentTransaction.OrderId,
                Amount = paymentTransaction.Amount,
                ClientId = paymentTransaction.ClientId,
                CreatedAt = paymentTransaction.CreatedAt,
                UpdatedAt = paymentTransaction.UpdatedAt,
                Status = (TransactionState)paymentTransaction.Status,
            });
    }
}