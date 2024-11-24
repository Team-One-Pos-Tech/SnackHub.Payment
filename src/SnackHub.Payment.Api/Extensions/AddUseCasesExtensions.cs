using SnackHub.Payment.Application.Contracts;
using SnackHub.Payment.Application.UseCases;

namespace SnackHub.Payment.Api.Extensions;

public static class AddUseCasesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IListPaymentUseCase, ListPaymentUseCase>()
            .AddScoped<IPaymentManagerUseCase, PaymentManagerUseCase>();
    }
}