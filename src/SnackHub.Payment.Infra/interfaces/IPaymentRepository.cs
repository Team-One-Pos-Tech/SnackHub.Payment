using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Infra.interfaces;

public interface IPaymentRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
{
    
}