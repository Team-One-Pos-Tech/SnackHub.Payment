using System;
using Refit;

namespace SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.POS;

public record QrDetails
{
    [AliasAs("category")]
    public string Image { get; set; }
    
    [AliasAs("category")]
    public string TemplateDocument { get; set; }
    
    [AliasAs("category")]
    public string TemplateImage { get; set; }
}

public record CreatePosResponse
{
    
    [AliasAs("id")]
    public int Id { get; set; }
    
    [AliasAs("qr")]
    public QrDetails QrDetails { get; set; }
    
    [AliasAs("status")]
    public string Status { get; set; }
    
    [AliasAs("date_created")]
    public DateTime DateCreated { get; set; }
    
    [AliasAs("date_last_updated")]
    public DateTime DateLastUpdated { get; set; }
    
    [AliasAs("uuid")]
    public string Uuid { get; set; }
    
    [AliasAs("user_id")]
    public int UserId { get; set; }
    
    [AliasAs("name")]
    public string Name { get; set; }
    
    [AliasAs("fixed_amount")]
    public bool FixedAmount { get; set; }
    
    [AliasAs("category")]
    public int Category { get; set; }
    
    [AliasAs("store_id")]
    public string StoreId { get; set; }
    
    [AliasAs("external_store_id")]
    public string ExternalStoreId { get; set; }
    
    [AliasAs("external_id")]
    public string ExternalId { get; set; }
    
    [AliasAs("site")]
    public string Site { get; set; }
    
    [AliasAs("qr_code")]
    public string QrCode { get; set; }
}

