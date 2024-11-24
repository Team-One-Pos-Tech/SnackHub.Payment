using System;

namespace SnackHub.Payment.Domain.Entities;

public record Client(Guid Identifier, string Name, string Email);