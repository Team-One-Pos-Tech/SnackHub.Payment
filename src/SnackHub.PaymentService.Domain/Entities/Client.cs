using System;

namespace SnackHub.PaymentService.Domain.Entities;

public record Client(Guid Id, string Name, string Cpf, string? Email = null);