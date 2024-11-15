using AutoMapper;
using SnackHub.Payment.Application.ViewModel.Payment;

namespace SnackHub.Payment.Application.Mappers.PaymentMapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<MercadoPago.Resource.Payment.PaymentPayer, Domain.Entities.Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerRefID, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ReverseMap();

            CreateMap<MercadoPago.Resource.Payment.Payment, Domain.Entities.Payment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GatewayRefID, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(x => x.DateCreated))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.TransactionAmount))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(x => x.Status))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(x => x.PaymentMethodId))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Payer)).ReverseMap();

            CreateMap<PaymentVM, Domain.Entities.Payment>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Amount))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(x => x.DateCreated))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer)).ReverseMap();
        }
    }
}
