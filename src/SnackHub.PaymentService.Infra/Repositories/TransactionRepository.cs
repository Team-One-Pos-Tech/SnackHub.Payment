using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Entities;
using SnackHub.PaymentService.Domain.Enums;
using SnackHub.PaymentService.Infra.Repositories.Contexts;

namespace SnackHub.PaymentService.Infra.Repositories;

public class TransactionRepository : BaseRepository<PaymentTransaction, PaymentContext>, ITransactionRepository
{
    public TransactionRepository(
        PaymentContext dbContext, 
        ILogger<TransactionRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task CreateAsync(PaymentTransaction paymentTransaction)
    {
        await InsertAsync(paymentTransaction);
    }

    public async Task CreateManyAsync(IEnumerable<PaymentTransaction> paymentTransactions)
    {
        await InsertManyAsync(paymentTransactions);
    }
    
    public async Task EditAsync(PaymentTransaction paymentTransaction)
    {
        await UpdateAsync(paymentTransaction);
    }

    public async Task<PaymentTransaction?> GetByIdAsync(Guid id)
    {
        return await FindByPredicateAsync(transaction => transaction.Id.Equals(id));
    }
    
    public async Task<IEnumerable<PaymentTransaction>> ListTransactionsStateAsync(PaymentTransactionState transactionState)
    {
        return await ListByPredicateAsync(transaction => transaction.Status.Equals(transactionState)) ?? [];
    }
}