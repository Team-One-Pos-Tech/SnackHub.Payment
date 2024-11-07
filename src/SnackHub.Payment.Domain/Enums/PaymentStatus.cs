namespace SnackHub.Payment.Domain.Enums;

public enum PaymentStatus
{
    Todo = 1,
    InProgress,
    Pending,
    Overdue,
    Cancelled,
    Completed,
    CancelledByUser,
}