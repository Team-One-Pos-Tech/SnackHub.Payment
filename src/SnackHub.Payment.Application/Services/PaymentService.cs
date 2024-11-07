using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services;

public class PaymentService : BaseReadOnlyService<Domain.Entities.Payment, Domain.Entities.Payment, Guid, FilterBase>
{
    public PaymentService(ILogger<Domain.Entities.Payment> logger, IMapper mapper, IRepository<Domain.Entities.Payment> repository) 
        : base(logger, mapper, repository)
    {
    }
}