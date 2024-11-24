using System;

namespace SnackHub.Payment.Domain.Entities;

public record Client(Guid Id, string Name, string Cpf, string? Email = null);