using System.Linq.Expressions;
using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Infra.interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
{
    /// <summary>
    /// Inseri entidade no banco.
    /// </summary>
    /// <param name="entity">Objeto generico.</param>
    /// <returns>TEntity</returns>
    Task<TEntity> Insert(TEntity entity);
    /// <summary>
    /// Atualiza a entidade
    /// </summary>
    /// <param name="entity">Objeto generico.</param>
    /// <returns>TEntity</returns>
    Task<TEntity> Update(TEntity entity);
    /// <summary>
    /// Deleta a entidade.
    /// </summary>
    /// <param name="entity">Objeto generico.</param>
    /// <returns>TEntity</returns>
    Task<TEntity> Delete(TEntity entity);
    /// <summary>
    /// Buscar entidade por id.
    /// obs: basta informa o id da entidade.
    /// </summary>
    /// <param name="entity">Objeto generico.</param>
    /// <returns>TEntity</returns>
    Task<TEntity?> GetById(TEntity entity);
    /// <summary>
    /// Retorna uma lista de entidade.
    /// </summary>
    /// <returns>IEnumerable<TEntity></returns>
    Task<IEnumerable<TEntity>> GetAll();
    /// <summary>
    /// Retorna uma lista de entidade.
    /// obs: possibilidade de filtro.
    /// </summary>
    /// <param name="predicate">Expressão linq.</param>
    /// <returns>IEnumerable<TEntity></returns>
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChenges();
}