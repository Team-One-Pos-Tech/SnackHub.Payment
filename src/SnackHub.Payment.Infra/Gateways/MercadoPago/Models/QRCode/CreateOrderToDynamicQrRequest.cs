using System.Collections.Generic;
using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models;

public record CreateOrderToDynamicQrRequest
{
    [AliasAs("external_reference")]
    public string ExternalReference { get; init; }
    
    [AliasAs("notification_url")]
    public string NotificationUrl { get; init; }
    
    [AliasAs("total_amount")]
    public double TotalAmount { get; init; }
    
    [AliasAs("items")]
    public IEnumerable<Item> Items { get; init; }
    
    [AliasAs("title")]
    public string Title { get; init; }
    
    [AliasAs("description")]
    public string Description { get; init; }
}

public record Item
{
    [AliasAs("sku_number")]
    public string SkuNumber { get; init; }
    
    [AliasAs("category")]
    public string Category { get; init; }
    
    [AliasAs("title")]
    public string Title { get; init; }
    
    [AliasAs("description")]
    public string Description { get; init; }
    
    [AliasAs("quantity")]
    public int Quantity { get; init; }
    
    [AliasAs("unit_measure")]
    public string UnitMeasure { get; init; }
    
    [AliasAs("unit_price")]
    public double UnitPrice { get; init; }
    
    [AliasAs("total_amount")]
    public double TotalAmount { get; init; }
}

