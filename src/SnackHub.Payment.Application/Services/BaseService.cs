using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Domain.Interface;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services;

public class BaseService<TInput, TOutput, TEntity, TPk, TFilter> : BaseReadOnlyService<TOutput, TEntity, TPk, TFilter>, IBaseService<TInput, TOutput, TPk, TFilter>
    where TInput : class
    where TOutput : class
    where TPk : IComparable 
    where TFilter : class, IFilter
    where TEntity : Entity<TPk>, IAggregateRoot
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IRepository<TEntity> _repository;
    
    public BaseService(ILogger logger, IMapper mapper, IRepository<TEntity> repository) : base(logger, mapper, repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }


    public virtual ResultBase<TOutput> Insert(TInput input)
    {
        try
        {
            _logger.LogInformation("insert");
            var entity = _mapper.Map<TEntity>(input);
            var resultRepository = _repository.Insert(entity);
            
            var data = _mapper.Map<TOutput>(resultRepository);
            
            return ResultBase<TOutput>
                .Success(data, ResultBase<TOutput>.CreatedMessages(1, "Incluido com suscesso!"));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return ResultBase<TOutput>.Failed(ResultBase<TOutput>.CreatedMessages(1, "Erro ao incluir dados!"));
        }
    }

    public virtual  ResultBase<TOutput> Update(TInput input)
    {
        try
        {
            _logger.LogInformation("update");
            var entity = _mapper.Map<TEntity>(input);
            var resultRepository = _repository.Insert(entity);
            
            var data = _mapper.Map<TOutput>(resultRepository);
            
            return ResultBase<TOutput>
                .Success(data, ResultBase<TOutput>.CreatedMessages(1, "Atualizado com suscesso!"));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return ResultBase<TOutput>.Failed(ResultBase<TOutput>.CreatedMessages(1, "Erro ao atualizar dados!"));
        }
    }

    public virtual  ResultBase<TOutput> Delete(TInput input)
    {
        throw new NotImplementedException();
    }
}