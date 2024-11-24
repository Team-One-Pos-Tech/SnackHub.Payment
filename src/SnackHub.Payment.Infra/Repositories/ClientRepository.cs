using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Domain.Contracts;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Infra.Contexts;

namespace SnackHub.Payment.Infra.Repositories;

public class ClientRepository : BaseRepository<Client, PaymentContext>, IClientRepository
{
    protected ClientRepository(
        PaymentContext dbContext,
        ILogger<ClientRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task AddAsync(Client client)
    {
        await InsertAsync(client);
    }

    public async Task RemoveAsync(Guid identifier)
    {
        await DeleteByPredicateAsync(client => client.Identifier.Equals(identifier));
    }

    public async Task<Client?> GetByIdentifierAsync(Guid id)
    {
        return await FindByPredicateAsync(x => x.Identifier.Equals(id));
    }
}