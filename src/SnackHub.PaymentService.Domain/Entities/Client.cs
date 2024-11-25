using System;

namespace SnackHub.PaymentService.Domain.Entities;

public class Client
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Cpf { get; init; }
    public string? Email { get; init; }

    public static Client Create(Guid id, string name, string cpf, string? email = null) => new Client
    {
        Id = id,
        Name = name,
        Cpf = cpf,
        Email = email
    };
}