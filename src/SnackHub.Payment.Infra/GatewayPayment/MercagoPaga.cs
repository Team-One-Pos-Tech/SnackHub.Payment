using AutoMapper;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Infra.interfaces;
using MercadoPago.Client;
using MercadoPago.Client.Customer;
using MercadoPago.Client.Payment;
using MercadoPago.Http;

namespace SnackHub.Payment.Infra.GatewayPayment;

public class MercagoPaga : IGatewayPayment
{
    private readonly CustomerClient _client;
    private readonly IMapper _mapper;
    
    public MercagoPaga(IMapper mapper)
    {
        _mapper = mapper;
        _client = new CustomerClient();
    }
    public Customer CreateCustomer(Customer customer)
    {
        try
        {
            var request = _mapper.Map<CustomerRequest>(customer);
            var customerapi = _client.Create(request);
            customer.CustomerMPId = customerapi.Id;
            return customer;
        }
        catch (Exception e)
        {
            throw;
        }
        
    }

    public List<Customer> ListCustomers()
    {
        try
        {
            var customersApi = _client.Search(new SearchRequest()
            {
                
            });
            return _mapper.Map<List<Customer>>(customersApi.Results);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}