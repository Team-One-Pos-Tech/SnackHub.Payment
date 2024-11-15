using AutoMapper;
using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Application.Mappers.CustomeMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerVM, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(x => x.Phone))
                .ReverseMap();

            CreateMap<MercadoPago.Resource.Customer.Customer, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(x => x.Phone))

                .ReverseMap();
        }
    }
}
