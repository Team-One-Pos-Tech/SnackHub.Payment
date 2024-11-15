using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Application.ViewModel;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services;

internal class PaymentService : ServiceAuditavel, IPaymentService
{
    public PaymentService(ILogger<Domain.Entities.Payment> logger, IMapper mapper) : base(logger, mapper)
    {
    }

    public ResultBase<CustomerVM> GetCustomerByPayment(int id)
     => ResultOperation<CustomerVM>(() => {  return default; });
}