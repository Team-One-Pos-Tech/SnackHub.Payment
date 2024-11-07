namespace SnackHub.Payment.Infra.interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}