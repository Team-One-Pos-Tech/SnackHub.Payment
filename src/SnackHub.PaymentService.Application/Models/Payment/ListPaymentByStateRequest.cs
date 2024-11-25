using SnackHub.PaymentService.Application.Models.Payment.Enums;

namespace SnackHub.PaymentService.Application.Models.Payment;

public record ListPaymentByStateRequest(TransactionState State);