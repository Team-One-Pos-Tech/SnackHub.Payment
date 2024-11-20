using AutoMapper;
using MercadoPago.Client;
using MercadoPago.Client.Customer;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Http;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Infra.interfaces;

namespace SnackHub.Payment.Infra.GatewayPayment;

public class MercagoPagaGateway : IGatewayPayment
{
    private readonly RequestOptions _options;
    private readonly CustomerClient _customerClient;
    private readonly PaymentClient _paymentClient;
    private readonly IMapper _mapper;
    private readonly ILogger<MercagoPagaGateway> _logger;
    public MercagoPagaGateway(ILogger<MercagoPagaGateway> logger, IMapper mapper, Domain.Settings settings)
    {
        _logger = logger;
        _mapper = mapper;
        MercadoPagoConfig.AccessToken = settings.MercadoPago.AccessToken;
        _options = new RequestOptions();
        _options.AccessToken = settings.MercadoPago.AccessToken;
        _options.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, settings.MercadoPago.PublicKey);
        _customerClient = new CustomerClient();
        _paymentClient = new PaymentClient();
    }
    public Customer CreateCustomer(Customer customer)
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de criar cliente.");
            var request = _mapper.Map<CustomerRequest>(customer);
            var customerapi = _customerClient.Create(request, _options);
            customer.CustomerRefID = customerapi.Id;
            return customer;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao tentar criar cliente, tente novamente mais tarde!");
            throw;
        }

    }

    public Customer GetCustomer(string id)
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de buscar cliente");
            var customer = _customerClient.Get(id, _options);
            var output = _mapper.Map<MercadoPago.Resource.Customer.Customer, Customer>(customer);
            return output;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao tentar buscar cliente, tente novamente mais tarde!");
            throw;
        }
    }

    public List<Customer> GetCustomerByEmail(string email)
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de buscar cliente");
            var search = new SearchRequest();
            search.Filters = new Dictionary<string, object>();
            search.Filters.Add("email", email);
            var customer = _customerClient.Search(search, _options);
            var output = _mapper.Map<IList<MercadoPago.Resource.Customer.Customer>, List<Customer>>(customer.Results);
            return output;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao tentar buscar cliente, tente novamente mais tarde!");
            throw;
        }
    }

    public Domain.Entities.Payment GetCustomerByPayment(string id)
     => this.GetPayment(id);

    public Domain.Entities.Payment GetPayment(string id)
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de criar pagamento");
            long.TryParse(id, out var paymentid);
            var paymentResponse = _paymentClient.Get(paymentid, _options);
            var output = _mapper.Map<MercadoPago.Resource.Payment.Payment, Domain.Entities.Payment>(paymentResponse);
            return output;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao tentar criar pagamento, tente novamente mais tarde!");
            throw;
        }
    }

    public List<Customer> ListCustomers()
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de criar pagamento");
            var customersApi = _customerClient.Search(new SearchRequest());
            return _mapper.Map<List<Customer>>(customersApi.Results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Ocorreu um erro ao tentar criar pagamento, tente novamente mais tarde!");
            throw;
        }
    }

    public Domain.Entities.Payment PaymentCreate(Domain.Entities.Payment input)
    {
        try
        {
            _logger.LogInformation("Usuário iniciou processo de criar pagamento");
            var request = _mapper.Map<Domain.Entities.Payment, PaymentCreateRequest>(input);
            var paymentResponse = _paymentClient.Create(request, _options);
            var output = _mapper.Map<MercadoPago.Resource.Payment.Payment, Domain.Entities.Payment>(paymentResponse);
            return output;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao tentar criar pagamento, tente novamente mais tarde!");
            throw;
        }
    }
}