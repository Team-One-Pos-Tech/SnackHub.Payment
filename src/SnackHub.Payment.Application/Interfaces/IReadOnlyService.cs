namespace SnackHub.Payment.Application.Interfaces;

public interface IReadOnlyService<TOutput, TPk, TFilter>
    where TOutput : class
    where TPk : IComparable 
    where TFilter : IFilter
{
    ResultBase<IReadOnlyList<TOutput>> GetAll(TFilter filter);
    ResultBase<IReadOnlyList<TOutput>> Get(TFilter filter, TPk id);
}