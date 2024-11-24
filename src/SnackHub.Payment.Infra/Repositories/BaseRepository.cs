using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Infra.Extensions;
using SnackHub.Payment.Infra.Repositories.Abstractions;

namespace SnackHub.Payment.Infra.Repositories;

public class BaseRepository<TModel, TDbContext> : IBaseRepository<TModel>
    where TModel : class
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DbSet<TModel> _dbSet;
    
    private readonly ILogger<BaseRepository<TModel, TDbContext>> _logger;

    protected HashSet<string> _expandProperties = new();

    protected BaseRepository(TDbContext dbContext, 
        ILogger<BaseRepository<TModel, TDbContext>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        _dbSet = _dbContext.Set<TModel>();
    }

    public async Task InsertAsync(TModel model)
    {
        await _dbSet.AddAsync(model);
        await CompleteAsync();
    }
    
    public async Task InsertManyAsync(IEnumerable<TModel> models)
    {
        await _dbSet.AddRangeAsync(models);
        await CompleteAsync();
    }

    public async Task UpdateAsync(TModel model)
    {
        _dbSet.Update(model);
        await CompleteAsync();
    }

    public async Task DeleteByPredicateAsync(Expression<Func<TModel, bool>> predicate)
    {
        var model = await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .FirstOrDefaultAsync();

        if (model is null)
            return;

        _dbSet.Remove(model);
        await CompleteAsync();
    }
    
    public async Task<IEnumerable<TModel>> ListByPredicateAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await _dbSet
            .AsNoTracking()
            .Inflate(_expandProperties)
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<TModel?> FindByPredicateAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await _dbSet
            .AsNoTracking()
            .Inflate(_expandProperties)
            .Where(predicate)
            .FirstOrDefaultAsync();
    }
    
    private async Task CompleteAsync()
    {
        //TODO: Move it to a better context {UnitOfWork or Transactions based}
        _logger.LogInformation("Storing context data!");
        await _dbContext.SaveChangesAsync();
        _dbContext.ChangeTracker.Clear();
    }
}