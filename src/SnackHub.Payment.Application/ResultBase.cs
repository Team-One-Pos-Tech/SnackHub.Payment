using System.Diagnostics.CodeAnalysis;
using FluentValidation.Results;

namespace SnackHub.Payment.Application;
public class ResultBase<TOutput> where TOutput : class
{
    public bool IsSuccess { get; private set; }
    public List<Messagem> Messagens { get; private set; } = Enumerable.Empty<Messagem>().ToList();
    public required TOutput Data { get; set; }
    
    [SetsRequiredMembers]
    public ResultBase(bool success, TOutput data, List<Messagem> messages)
    {
        this.IsSuccess = success;
        this.Messagens = messages;
        this.Data = data;
    }
    [SetsRequiredMembers]
    public ResultBase(ValidationResult validationResult)
    {
        this.IsSuccess = validationResult.IsValid;
        Messagens.AddRange(validationResult.Errors.Select(x => 
            new Messagem(x.PropertyName, x.ErrorMessage)));
    }

    #region Public método.
    public static List<Messagem> CreatedMessages(int code, string descripion)
     => new List<Messagem>(1)
     {
         new Messagem($"AS{code.ToString()}", descripion)
     };

    public static ResultBase<TOutput> Success(TOutput data, List<Messagem> messages)
     => new ResultBase<TOutput>(true, data, messages);

    public static ResultBase<TOutput> Failed(ValidationResult validationResult)
     => new ResultBase<TOutput>(validationResult);

    public static ResultBase<TOutput> Failed(List<Messagem> messages)
     => new ResultBase<TOutput>(false, default, messages);

    #endregion
}