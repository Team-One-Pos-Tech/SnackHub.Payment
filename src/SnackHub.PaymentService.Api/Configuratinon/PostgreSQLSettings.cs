namespace SnackHub.PaymentService.Api.Configuratinon;

public record PostgreSQLSettings
{
    public string Host { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
}