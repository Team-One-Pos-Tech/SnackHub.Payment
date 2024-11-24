using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models;

public record CreateOrderToDynamicQrResponse
{
    [AliasAs("in_store_order_id")]
    public string InStoreOrderId { get; init; }
    
    [AliasAs("qr_data")]
    public string QrData { get; init; }
}