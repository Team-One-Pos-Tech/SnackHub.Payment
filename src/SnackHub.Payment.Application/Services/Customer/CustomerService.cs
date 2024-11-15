using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces.Customer;
using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Application.Services.Customer;

internal class CustomerService : ServiceAuditavel, ICustomerService
{
    private readonly IGatewayPayment _gatewayPayment;
    public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IGatewayPayment gatewayPayment) : base(logger, mapper)
    {
        _gatewayPayment = gatewayPayment;
    }

    public ResultBase<CustomerVM> CreateCustomer(CustomerInput input)
    {
        throw new NotImplementedException();
    }

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