using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Entities;
using SnackHub.PaymentService.Infra.Repositories.Contexts;

namespace SnackHub.PaymentService.Infra.Repositories;

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