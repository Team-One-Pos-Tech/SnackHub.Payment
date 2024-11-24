using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Domain.Enums;

namespace SnackHub.Payment.Domain.Contracts;

public interface ITransactionRepository
{
    Task CreateAsync(PaymentTransaction paymentTransaction);
    Task EditAsync(PaymentTransaction paymentTransaction);

    Task<PaymentTransaction?> GetByIdAsync(Guid id);
    Task<PaymentTransaction?> GetTransactionByOrderIdAsync(Guid orderId);
    Task<IEnumerable<PaymentTransaction>> ListTransactionsByClientIdAsync(Guid clientId);
    
    Task<IEnumerable<PaymentTransaction>> ListTransactionsStateAsync(PaymentTransactionState transactionState);

}