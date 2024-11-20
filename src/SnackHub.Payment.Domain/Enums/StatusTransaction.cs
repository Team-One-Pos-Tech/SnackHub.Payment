namespace SnackHub.Payment.Domain.Enums;

public enum StatusTransaction
{
    Authorized = 1,
    Paid,
    Refused,
    Chargedback,
    Cancelled
}