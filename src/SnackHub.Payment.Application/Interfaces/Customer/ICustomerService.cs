using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Application.Interfaces.Customer;

public interface ICustomerService : IBaseService
{
    ResultBase<CustomerVM> CreateCustomer(CustomerInput input);
    ResultBase<CustomerVM> UpdateCustomer(CustomerInput input, Guid id);
    ResultBase<CustomerVM> GetCustomer(Guid id);
    ResultBase<List<CustomerVM>> GetCustomer();
    ResultBase<List<CustomerVM>> GetCustomerByEmail(string email);

}