using System;

namespace SnackHub.Payment.Application.Models.Payment;

public record PaymentRejectRequest(Guid TransactionId);