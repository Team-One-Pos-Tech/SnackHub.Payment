using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SnackHub.PaymentService.Domain.Entities;
using SnackHub.PaymentService.Domain.Enums;

namespace SnackHub.PaymentService.Infra.Repositories.Maps;

public class PaymentTransactionMap : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
    {
        builder
            .ToTable("Transactions")
            .HasKey(px => px.Id);
        
        builder
            .Property(px => px.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(px => px.OrderId)
            .HasColumnName("OrderId")
            .IsRequired();

        builder
            .Property(px => px.ClientId)
            .HasColumnName("ClientId")
            .IsRequired();
        
        builder
            .Property(px => px.Amount)
            .HasColumnName("Amount")
            .IsRequired();

        builder
            .Property(px => px.Status)
            .HasColumnName("Status")
            .HasConversion<EnumToStringConverter<PaymentTransactionState>>()
            .IsRequired();      
        
        builder
            .Property(px => px.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder
            .Property(px => px.UpdatedAt)
            .HasColumnName("UpdatedAt");
        
    }
}