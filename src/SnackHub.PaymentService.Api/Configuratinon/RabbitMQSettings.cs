namespace SnackHub.PaymentService.Api.Configuratinon;

public record RabbitMqSettings
{
    public required string Host { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}