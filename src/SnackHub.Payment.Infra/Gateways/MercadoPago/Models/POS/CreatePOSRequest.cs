using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models.POS;

public record CreatePosRequest
{
    [AliasAs("category")]
    public int Category { get; set; }
    
    [AliasAs("external_id")]
    public string ExternalId { get; set; }
    
    [AliasAs("external_store_id")]
    public string ExternalStoreId { get; set; }
    
    [AliasAs("fixed_amount")]
    public bool FixedAmount { get; set; }
    
    [AliasAs("name")]
    public string Name { get; set; }
    
    [AliasAs("store_id")]
    public int StoreId { get; set; }
}