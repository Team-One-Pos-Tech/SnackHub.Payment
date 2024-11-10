namespace SnackHub.Payment.Application.Interfaces;

public interface IBaseService<in TInput, TOutput, in TPk, in TFilter>
    where TInput : class
    where TOutput : class
    where TPk : IComparable 
    where TFilter : IFilter
{
    ResultBase<TOutput> Insert(TInput input);
    ResultBase<TOutput> Update(TInput input);
    ResultBase<TOutput> Delete(TInput input);
}