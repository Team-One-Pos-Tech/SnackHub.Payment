using Refit;

namespace SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.Store;

public record WorkingHours
{
    [AliasAs("open")]
    public string Open { get; set; }
    
    [AliasAs("close")]
    public string Close { get; set; }
}