using System;
using MassTransit;
using SnackHub.PaymentService.Application.Models.Payment.Enums;

namespace SnackHub.PaymentService.Application.Models.Payment;

[MessageUrn("snack-hub-payments")]
[EntityName("payment-status-updated")]
public record PaymentStatusUpdated(Guid OrderId, Guid TransactionId, TransactionState Status);