using System.Collections.Generic;
using Refit;

namespace SnackHub.PaymentService.Infra.Gateways.MercadoPago.Models.Store;

public record BusinessHours
{
    [AliasAs("monday")]
    public List<WorkingHours> Monday { get; set; }
    
    [AliasAs("tuesday")]
    public List<WorkingHours> Tuesday { get; set; }
    
    [AliasAs("wednesday")]
    public List<WorkingHours> Wednesday { get; set; }
    
    [AliasAs("thuesday")]
    public List<WorkingHours> Thuesday { get; set; }
    
    [AliasAs("friday")]
    public List<WorkingHours> Friday { get; set; }
    
    [AliasAs("saturday")]
    public List<WorkingHours> Saturday { get; set; }
    
    [AliasAs("sunday")]
    public List<WorkingHours> Sunday { get; set; }
}