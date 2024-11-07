using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SnackHub.Payment.Domain.Interface;
using SnackHub.Payment.Infra.Contexts;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Infra.Repositories;

public class Repository<TEntity> : IRepository<TEntity>  where TEntity : class, IAggregateRoot
{
    private readonly PaymentContext _context;
    private readonly DbSet<TEntity> _DbSet;
    private readonly string _connectionString;
    public IUnitOfWork UnitOfWork { get; }

    public Repository(PaymentContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        UnitOfWork = unitOfWork;
        _DbSet = context.Set<TEntity>();
        _connectionString = _context.Database.GetDbConnection().ConnectionString;
    }
    public virtual async Task Delete(TEntity entity)
    {
        _DbSet.Remove(entity);
        await SaveChenges();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _DbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await _DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(TEntity entity)
    {
        return await _DbSet.FindAsync(entity);
    }

    public virtual async Task<TEntity> Insert(TEntity entity)
    {
        _DbSet.Add(entity);
        await SaveChenges();
        return entity;
    }

    public async Task<int> SaveChenges()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _DbSet.Update(entity);
        await SaveChenges();
        return entity;
    }

    Task<TEntity> IRepository<TEntity>.Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

}