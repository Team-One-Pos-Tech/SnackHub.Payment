using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace SnackHub.Payment.Application.Services
{
    internal abstract class ServiceAuditavel : BaseService
    {
        public ServiceAuditavel(ILogger logger, IMapper mapper) : base(logger, mapper)
        {
        }

        public ResultBase<TOutPut> ResultOperation<TOutPut>(ValidationResult validator = null, Func<TOutPut> operation = default) where TOutPut : class
        {
            try
            {
                if (validator is not null || validator != default)
                    if (!validator.IsValid)
                        return ResultBase<TOutPut>.Failed(validator);

                if (operation() == default)
                    return ResultBase<TOutPut>.Failed(ResultBase<TOutPut>.CreatedMessages(1, "Ocorreu um erro, tente novamente mais tarde!"));


                return ResultBase<TOutPut>
                .Success(operation(), ResultBase<TOutPut>.CreatedMessages(1, "Operacação realizada com sucesso!"));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return ResultBase<TOutPut>.Failed(ResultBase<TOutPut>.CreatedMessages(1, "Falha ao tentar realizar operação!"));
            }
        }
    }
}
