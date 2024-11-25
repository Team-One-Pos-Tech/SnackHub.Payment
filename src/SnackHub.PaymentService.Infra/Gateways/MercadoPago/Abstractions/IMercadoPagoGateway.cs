using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.POS;
using SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.QRCode;
using SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.Store;

namespace SnackHub.PaymentService.Infra.Gateways.MercadoPago.Abstractions;


/// <summary>
/// More details here: https://documenter.getpostman.com/view/15366798/2sAXjKasp4#9057a4e4-3edd-414f-85c4-978681fd5cc6
/// </summary>
public interface IMercadoPagoGateway
{
    [Headers("Authorization: Bearer")]
    [Post("users/{userId}/stores")]
    Task<CreateStoreResponse> CreateStoreAsync([FromRoute] string userId, [FromBody] CreateStoreRequest createStoreRequest);

    [Headers("Authorization: Bearer")]
    [Post("pos")]
    Task<CreatePosResponse> CreatePoSAsync([FromBody] CreatePosRequest createPosRequest);
    
    [Headers("Authorization: Bearer")]
    [Post("instore/orders/qr/seller/collectors/{userId}/pos/{externalPosId}/qrs")]
    Task<CreateOrderToDynamicQrResponse> CreateOrderToStaticQrCodeAsync([FromRoute] string userid, [FromRoute] string externalPosId, [FromBody] CreateOrderToDynamicQrRequest createOrderToDynamicQrRequest);
}