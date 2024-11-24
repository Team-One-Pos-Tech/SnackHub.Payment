using Microsoft.EntityFrameworkCore;

namespace SnackHub.Payment.Infra.Contexts;

public class PaymentContext : DbContext
{
    public PaymentContext(DbContextOptions<PaymentContext> dbContextOptions)
        : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}