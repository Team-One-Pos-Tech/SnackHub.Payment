using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackHub.Payment.Domain.Entities;

namespace SnackHub.Payment.Infra.Repositories.Maps;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .ToTable("Clients")
            .HasKey(px => px.Id);

        builder
            .Property(px => px.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(px => px.Name)
            .HasColumnName("Name")
            .IsRequired();

        builder
            .Property(px => px.Cpf)
            .HasColumnName("Cpf")
            .IsRequired();

        builder
            .Property(px => px.Email)
            .HasColumnName("Email");
    }
}