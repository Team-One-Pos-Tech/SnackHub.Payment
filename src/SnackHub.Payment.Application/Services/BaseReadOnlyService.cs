using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Domain.Interface;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services;

public class BaseReadOnlyService<TOutput, TEntity, TPk, TFilter> : IReadOnlyService<TOutput, TPk, TFilter>
    where TOutput : class
    where TPk : IComparable 
    where TFilter : IFilter
    where TEntity : Entity<TPk>, IAggregateRoot
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IRepository<TEntity> _repository;
    public BaseReadOnlyService(ILogger logger, IMapper mapper, IRepository<TEntity> repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }
    public virtual ResultBase<IReadOnlyList<TOutput>> GetAll(TFilter filter)
    {
        try
        {
            _logger.LogInformation("Get all");
            var resultRepository = _repository.GetAll();
            
            var data = _mapper.Map<IReadOnlyList<TOutput>>(resultRepository);
            
            return ResultBase<IReadOnlyList<TOutput>>
                .Success(data, ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Busca realizada com sucesso!"));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return ResultBase<IReadOnlyList<TOutput>>.Failed(ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Erro ao obter os dados!"));
        }
    }

    public virtual ResultBase<IReadOnlyList<TOutput>> Get(TFilter filter, TPk id)
    {
        try
        {
            _logger.LogInformation("Get all");
            var resultRepository = _repository.GetAll(x => x.Id.Equals(id));
            
            var data = _mapper.Map<IReadOnlyList<TOutput>>(resultRepository);
            
            return ResultBase<IReadOnlyList<TOutput>>
                .Success(data, ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Busca realizada com sucesso!"));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return ResultBase<IReadOnlyList<TOutput>>.Failed(ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Erro ao obter os dados!"));
        }
    }
}