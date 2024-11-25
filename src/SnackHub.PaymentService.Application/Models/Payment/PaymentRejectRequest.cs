using System;

namespace SnackHub.PaymentService.Application.Models.Payment;

public record PaymentRejectRequest(Guid TransactionId);