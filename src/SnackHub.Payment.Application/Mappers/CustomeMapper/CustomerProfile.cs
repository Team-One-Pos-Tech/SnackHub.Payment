using AutoMapper;
using SnackHub.Payment.Application.ViewModel;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Application.Mappers.CustomeMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerVM, Customer>();
        }
    }
}
