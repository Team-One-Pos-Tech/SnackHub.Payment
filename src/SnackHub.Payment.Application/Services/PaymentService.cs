using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Application.ViewModel;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services;

internal class PaymentService : ServiceAuditavel, IPaymentService
{
    private readonly IGatewayPayment _gatewayPayment;
    public PaymentService(ILogger<PaymentService> logger, IMapper mapper, IGatewayPayment gatewayPayment) : base(logger, mapper)
    {
        _gatewayPayment = gatewayPayment;
    }

    public ResultBase<CustomerVM> GetCustomerByPayment(string id)
     => ResultOperation<CustomerVM>(() => {  return default; });

    public ResultBase<PaymentVM> GetPayment(string id)
     => ResultOperation<PaymentVM>(() => 
     { 
         var payment = _gatewayPayment.GetPayment(id);
         return Mapper.Map<PaymentVM>(payment);
     });
}