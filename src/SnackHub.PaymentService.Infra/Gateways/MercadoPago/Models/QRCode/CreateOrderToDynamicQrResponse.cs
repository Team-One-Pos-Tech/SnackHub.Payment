using Refit;

namespace SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.QRCode;

public record CreateOrderToDynamicQrResponse
{
    [AliasAs("in_store_order_id")]
    public string InStoreOrderId { get; init; }
    
    [AliasAs("qr_data")]
    public string QrData { get; init; }
}