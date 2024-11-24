using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SnackHub.Payment.Infra.Repositories.Contexts;
using Testcontainers.PostgreSql;

namespace SnackHub.Payment.Test.Fixtures;

public abstract class PostgreSqlFixture
{
    private const int PostgresPublicPort = 5432;
    private const string PostgresRootPassword = "postgres";

    private PostgreSqlContainer _postgresContainer;

    protected PaymentContext PaymentContext;
    
    [SetUp]
    protected async Task BaseSetUp()
    {
        _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase("SnackHubIntegrationTests")
            .WithUsername("postgres")
            .WithPassword(PostgresRootPassword)
            .WithPortBinding(PostgresPublicPort, true)
            .WithCleanUp(true)
            .WithWaitStrategy(Wait
                .ForUnixContainer()
                .UntilPortIsAvailable(PostgresPublicPort))
            .Build();

        await _postgresContainer.StartAsync();
        
        var dbContextOptions = new DbContextOptionsBuilder<PaymentContext>()
            .UseNpgsql(_postgresContainer.GetConnectionString())
            .Options;

        PaymentContext = new PaymentContext(dbContextOptions);
        await PaymentContext.Database.EnsureCreatedAsync();
        
    }

    [TearDown]
    protected async Task BaseTearDown()
    {
        await _postgresContainer.StopAsync();
        await _postgresContainer.DisposeAsync();
    }
}