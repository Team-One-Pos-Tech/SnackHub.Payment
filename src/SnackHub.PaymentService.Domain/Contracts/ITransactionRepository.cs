using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnackHub.PaymentService.Domain.Entities;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Domain.Contracts;

public interface ITransactionRepository
{
    Task CreateAsync(PaymentTransaction paymentTransaction);
    Task CreateManyAsync(IEnumerable<PaymentTransaction> paymentTransactions);
    Task EditAsync(PaymentTransaction paymentTransaction);

    Task<PaymentTransaction?> GetByIdAsync(Guid id);
    Task<IEnumerable<PaymentTransaction>> ListTransactionsStateAsync(PaymentTransactionState transactionState);

}