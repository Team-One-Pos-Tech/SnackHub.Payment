using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Domain.Contracts;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Domain.Enums;
using SnackHub.Payment.Infra.Contexts;

namespace SnackHub.Payment.Infra.Repositories;

public class TransactionRepository : BaseRepository<PaymentTransaction, PaymentContext>, ITransactionRepository
{
    protected TransactionRepository(
        PaymentContext dbContext, 
        ILogger<TransactionRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task CreateAsync(PaymentTransaction paymentTransaction)
    {
        await InsertAsync(paymentTransaction);
    }

    public async Task EditAsync(PaymentTransaction paymentTransaction)
    {
        await UpdateAsync(paymentTransaction);
    }

    public async Task<PaymentTransaction?> GetByIdAsync(Guid id)
    {
        return await FindByPredicateAsync(transaction => transaction.Id.Equals(id));
    }

    public async Task<PaymentTransaction?> GetTransactionByOrderIdAsync(Guid orderId)
    {
        return await FindByPredicateAsync(transaction => transaction.OrderId.Equals(orderId));
    }

    public async Task<IEnumerable<PaymentTransaction>> ListTransactionsByClientIdAsync(Guid clientId)
    {
        return await ListByPredicateAsync(transaction => transaction.ClientId.Equals(clientId)) ?? [];
    }

    public async Task<IEnumerable<PaymentTransaction>> ListTransactionsStateAsync(PaymentTransactionState transactionState)
    {
        return await ListByPredicateAsync(transaction => transaction.Status.Equals(transactionState)) ?? [];
    }
}