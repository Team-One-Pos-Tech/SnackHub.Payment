using System;

namespace SnackHub.Payment.Application.Models.Payment;

public record PaymentApproveRequest(Guid TransactionId);