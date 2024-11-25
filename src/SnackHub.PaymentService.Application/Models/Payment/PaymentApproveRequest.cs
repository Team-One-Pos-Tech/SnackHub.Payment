using System;

namespace SnackHub.PaymentService.Application.Models.Payment;

public record PaymentApproveRequest(Guid TransactionId);