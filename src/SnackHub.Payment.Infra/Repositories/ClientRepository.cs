using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Domain.Contracts;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Infra.Repositories.Contexts;

namespace SnackHub.Payment.Infra.Repositories;

public class ClientRepository : BaseRepository<Client, PaymentContext>, IClientRepository
{
    public ClientRepository(
        PaymentContext dbContext,
        ILogger<ClientRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task AddAsync(Client client)
    {
        await InsertAsync(client);
    }
}