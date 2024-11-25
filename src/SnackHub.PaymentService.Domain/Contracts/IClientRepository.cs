using System;
using System.Threading.Tasks;
using SnackHub.PaymentService.Domain.Entities;

namespace SnackHub.PaymentService.Domain.Contracts;

public interface IClientRepository
{
    Task AddAsync(Client client);
}