using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces.Payment;
using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Application.ViewModel.Payment;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services.Payment;

internal class PaymentService : ServiceAuditavel, IPaymentService
{
    private readonly IGatewayPayment _gatewayPayment;
    public PaymentService(ILogger<PaymentService> logger, IMapper mapper, IGatewayPayment gatewayPayment) : base(logger, mapper)
    {
        _gatewayPayment = gatewayPayment;
    }

    public ResultBase<CustomerVM> GetCustomerByPayment(string id)
     => ResultOperation(() =>
     {
         var payment = _gatewayPayment.GetCustomerByPayment(id);
         return Mapper.Map<CustomerVM>(payment.Customer);
     });

    public ResultBase<PaymentVM> GetPayment(string id)
     => ResultOperation(() =>
     {
         var payment = _gatewayPayment.GetPayment(id);
         return Mapper.Map<PaymentVM>(payment);
     });
}