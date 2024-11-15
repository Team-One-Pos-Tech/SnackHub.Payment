using AutoMapper;
using SnackHub.Payment.Application.ViewModel;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Application.Mappers.CustomeMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerVM, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(x => x.Phone))
                .ReverseMap();
        }
    }
}
