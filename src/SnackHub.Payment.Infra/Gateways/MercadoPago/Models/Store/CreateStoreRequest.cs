using Refit;

namespace SnackHub.Payment.Infra.Gateways.MercadoPago.Models.Store;

public record CreateStoreRequest
{
    [AliasAs("business_hours")]
    public BusinessHours BusinessHours { get; set; }
    
    [AliasAs("external_id")]
    public string ExternalId { get; set; }
    
    [AliasAs("location")]
    public Location Location { get; set; }
    
    [AliasAs("name")]
    public string Name { get; set; }
}

public record CreateStoreLocation
{
    [AliasAs("street_number")]
    public string StreetNumber { get; set; }
    
    [AliasAs("street_name")]
    public string StreetName { get; set; }
    
    [AliasAs("city_name")]
    public string CityName { get; set; }
    
    [AliasAs("state_name")]
    public string StateName { get; set; }
    
    [AliasAs("latitude")]
    public double Latitude { get; set; }
    
    [AliasAs("longitude")]
    public double Longitude { get; set; }
    
    [AliasAs("reference")]
    public string Reference { get; set; }
}