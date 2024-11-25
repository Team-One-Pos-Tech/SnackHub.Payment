using SnackHub.PaymentService.Application.Contracts;
using SnackHub.PaymentService.Application.UseCases;

namespace SnackHub.PaymentService.Api.Extensions;

public static class AddUseCasesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IListPaymentUseCase, ListPaymentUseCase>()
            .AddScoped<IPaymentManagerUseCase, PaymentManagerUseCase>();
    }
}