using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models.Store;

public record WorkingHours
{
    [AliasAs("open")]
    public string Open { get; set; }
    
    [AliasAs("close")]
    public string Close { get; set; }
}