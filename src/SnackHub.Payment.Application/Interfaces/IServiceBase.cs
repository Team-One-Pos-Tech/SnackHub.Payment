namespace SnackHub.Payment.Application.Interfaces;

public interface IServiceBase<TInput, TOutput, TFilter> 
    where TInput : class 
    where TOutput : class 
    where TFilter : class
{
    ResultBase<TOutput> Insert(TInput input);
    ResultBase<TOutput> Update(TInput input);
    ResultBase<TOutput> Delete(TInput input);
}