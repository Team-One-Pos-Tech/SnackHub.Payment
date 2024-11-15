using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SnackHub.Payment.Application.Services
{
    internal abstract class ServiceAuditavel : BaseService
    {
        public ServiceAuditavel(ILogger logger, IMapper mapper) : base(logger, mapper)
        {
        }

        public ResultBase<TOutPut> ResultOperation<TOutPut>(Func<TOutPut> operation) where TOutPut : class
        {
            try
            {
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
