//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using SnackHub.Payment.Application.ViewModel;
//using SnackHub.Payment.Domain.Entities;
//using SnackHub.Payment.Infra.interfaces;

//namespace SnackHub.Payment.Application.Services;

//public class CustomerService : BaseService<CustomerVM, Customer, Customer, Guid, FilterBase>
//{
//    private readonly IGatewayPayment _gatewayPayment;
//    private readonly IMapper _mapper;
//    private readonly ILogger<CustomerService> _logger;
    
//    public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IRepository<Customer> repository, IGatewayPayment gatewayPayment) : base(logger, mapper, repository)
//    {
//        _logger = logger;
//        _mapper = mapper;
//        _gatewayPayment = gatewayPayment;
//    }

//    public override ResultBase<Customer> Insert(CustomerVM input)
//    {
        
//        try
//        {
//            var customerResult = base.Insert(input);
//           var customer = _gatewayPayment.CreateCustomer(customerResult.Data);
            
            
//            return ResultBase<Customer>
//                .Success(customerResult.Data, ResultBase<Customer>.CreatedMessages(1, "Incluido com suscesso!"));
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, e.Message);
//            return ResultBase<Customer>.Failed(ResultBase<Customer>.CreatedMessages(1, "Erro ao incluir dados!"));
//        }
       
//    }
//}