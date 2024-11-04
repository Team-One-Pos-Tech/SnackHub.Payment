using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;

namespace SnackHub.Payment.Application.Services;

public class BaseReadOnlyService<TOutput, TPk, TFilter> : IReadOnlyService<TOutput, TPk, TFilter>
    where TOutput : class
    where TPk : IComparable 
    where TFilter : IFilter
{
    private readonly ILogger<TOutput> _logger;
    private readonly IMapper _mapper;
    public BaseReadOnlyService(ILogger<TOutput> logger, IMapper mapper)
    {
        this._logger = logger;
        this._mapper = mapper;
    }
    public virtual ResultBase<IReadOnlyList<TOutput>> GetAll(TFilter filter)
    {
        try
        {
            _logger.LogInformation("Get all");
            
            
            return ResultBase<IReadOnlyList<TOutput>>
                .Success(default, ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Busca realizada com sucesso!"));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return ResultBase<IReadOnlyList<TOutput>>.Failed(ResultBase<IReadOnlyList<TOutput>>.CreatedMessages(1, "Erro ao obter os dados!"));
        }
    }

    public virtual ResultBase<IReadOnlyList<TOutput>> Get(TFilter filter, TPk id)
    {
        throw new NotImplementedException();
    }
}