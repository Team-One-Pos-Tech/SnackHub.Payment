using System;
using MassTransit;

namespace SnackHub.Payment.Application.Models.Payment;

[MessageUrn("snack-hub-payments")]
[EntityName("payment-requested")]
public record PaymentRequested(
    Guid OrderId,
    Guid? CustomerId,
    decimal Amount
);