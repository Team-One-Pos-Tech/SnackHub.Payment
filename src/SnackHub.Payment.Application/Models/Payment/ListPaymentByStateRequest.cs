using SnackHub.Payment.Application.Models.Payment.Enums;

namespace SnackHub.Payment.Application.Models.Payment;

public record ListPaymentByStateRequest(TransactionState State);