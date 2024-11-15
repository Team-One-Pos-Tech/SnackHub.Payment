using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces.Customer;
using SnackHub.Payment.Application.Validations.Customer;
using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services.Customer;

internal class CustomerService : ServiceAuditavel, ICustomerService
{
    private readonly IGatewayPayment _gatewayPayment;
    private readonly CustomerValidation _validations;
    public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IGatewayPayment gatewayPayment, CustomerValidation validations) : base(logger, mapper)
    {
        _gatewayPayment = gatewayPayment;
        _validations = validations;
    }

    public ResultBase<CustomerVM> CreateCustomer(CustomerInput input)
        => ResultOperation<CustomerVM>((_validations.Validate(input)), () =>
        {
            var domain = Mapper.Map<Domain.Entities.Customer>(input);
            var customer = _gatewayPayment.CreateCustomer(domain);
            return Mapper.Map<CustomerVM>(customer);
        });

    public ResultBase<CustomerVM> GetCustomer(Guid id)
    {
        throw new NotImplementedException();
    }

    public ResultBase<CustomerVM> GetCustomerByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public ResultBase<CustomerVM> UpdateCustomer(CustomerInput input, Guid id)
    {
        throw new NotImplementedException();
    }
}