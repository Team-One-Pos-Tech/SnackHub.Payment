using System;
using System.Collections.Generic;
using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models.Store;

public record CreateStoreResponse
{
    
    [AliasAs("id")]
    public BusinessHours Id { get; set; }
    
    [AliasAs("name")]
    public string Name { get; set; }
    
    [AliasAs("date_creation")]
    public DateTime DateCreation { get; set; }
    
    [AliasAs("business_hours")]
    public BusinessHours BusinessHours { get; set; }
    
    [AliasAs("location")]
    public Location Location { get; set; }
    
    [AliasAs("external_id")]
    public string ExternalId { get; set; }
}

public record Location
{
    [AliasAs("address_line")]
    public string AddressLine { get; set; }
    
    [AliasAs("reference")]
    public string Reference { get; set; }
    
    [AliasAs("latitude")]
    public double Latitude { get; set; }
    
    [AliasAs("longitude")]
    public double Longitude { get; set; }
    
    [AliasAs("id")]
    public string Id { get; set; }
    
    [AliasAs("type")]
    public string Type { get; set; }
    
    [AliasAs("city")]
    public string City { get; set; }
}



