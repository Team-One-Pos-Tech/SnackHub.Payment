using System;
using System.Threading.Tasks;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Domain.Contracts;

public interface IClientRepository
{
    Task AddAsync(Client client);
}