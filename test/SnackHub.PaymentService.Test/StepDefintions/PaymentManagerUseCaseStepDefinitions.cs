using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using Reqnroll;
using SnackHub.PaymentService.Application.Contracts;
using SnackHub.PaymentService.Application.Models.Payment;
using SnackHub.PaymentService.Application.Models.Payment.Enums;
using SnackHub.PaymentService.Application.UseCases;
using SnackHub.PaymentService.Domain.Contracts;
using SnackHub.PaymentService.Domain.Entities;
using SnackHub.PaymentService.Domain.Enums;
using SnackHub.PaymentService.Infra.Repositories;
using SnackHub.PaymentService.Test.Fixtures;

namespace SnackHub.PaymentService.Test.StepDefintions;

[Binding]
public class PaymentManagerUseCaseStepDefinitions : PostgreSqlFixture
{
    private IPaymentManagerUseCase _paymentManagerUseCase;
    private IListPaymentUseCase _listPaymentUseCase;
    
    private IClientRepository _clientRepository;
    private ITransactionRepository _transactionRepository;
    
    private Mock<IPublishEndpoint> _publishEndpointMock;
    
    [BeforeScenario]
    public async Task Setup()
    {
        await BaseSetUp();
        _publishEndpointMock = new Mock<IPublishEndpoint>();
        var clientLoggerMock = new Mock<ILogger<ClientRepository>>().Object;
        var transactionLoggerMock = new Mock<ILogger<TransactionRepository>>().Object;
        var useCaseLoggerMock = new Mock<ILogger<PaymentManagerUseCase>>().Object;
        
        var listPaymentUseCaseLoggerMock = new Mock<ILogger<ListPaymentUseCase>>().Object;
        
        _clientRepository = new ClientRepository(PaymentContext, clientLoggerMock);
        _transactionRepository = new TransactionRepository(PaymentContext, transactionLoggerMock);
        
        _paymentManagerUseCase = new PaymentManagerUseCase(useCaseLoggerMock, _transactionRepository, _publishEndpointMock.Object);
        _listPaymentUseCase = new ListPaymentUseCase(listPaymentUseCaseLoggerMock, _transactionRepository);
    }

    [Given("a client with id '(.*)' and name '(.*)' and CPF '(.*)'")]
    public async Task GivenAClientWithIdAndNameAndCpf(Guid id, string name, string cpf)
    {
        var client = new Client(id, name, cpf);
        await _clientRepository.AddAsync(client);
    }

    [Given("a payment transaction table")]
    public async Task GivenAPaymentTransactionTable(Table table)
    {
        var paymentTransaction = table.CreateInstance<PaymentTransaction>();
        paymentTransaction.Status = PaymentTransactionState.Accepted;
        
        await _transactionRepository.CreateAsync(paymentTransaction);
    }

    [When("submitting an approve payment request for transaction id '(.*)'")]
    public async Task WhenSubmittingAnApprovePaymentRequestForTransactionId(Guid transactionId)
    {
        var approveRequest = new PaymentApproveRequest(transactionId);
        await _paymentManagerUseCase.ExecuteAsync(approveRequest);
    }
    
    [When("submitting a reject payment request for transaction id '(.*)'")]
    public async Task WhenSubmittingARejectPaymentRequestForTransactionId(Guid transactionId)
    {
        var rejectRequest = new PaymentRejectRequest(transactionId);
        await _paymentManagerUseCase.ExecuteAsync(rejectRequest);
    }

    [Then("the transaction with id '(.*)' should have status '(.*)'")]
    public async Task ThenTheTransactionShouldHaveStatus(Guid transactionId, string expectedState)
    {
        Enum.TryParse(expectedState, out PaymentTransactionState state);

        var paymentTransaction = await _transactionRepository.GetByIdAsync(transactionId);
        
        paymentTransaction
            .Should()
            .NotBeNull();

        paymentTransaction
            .Status
            .Should()
            .Be(state);
    }

    [Given("a valid transaction table")]
    public async Task GivenAValidTransactionTable(Table table)
    {
        var paymentTransactions = table.CreateSet<PaymentTransaction>();
        await _transactionRepository.CreateManyAsync(paymentTransactions);
    }

    [Then("should rise the event PaymentStatusUpdated with status '(.*)'")]
    public void ThenShouldRiseTheEventPaymentStatusUpdatedWithStatus(string expectedState)
    {
        Enum.TryParse(expectedState, out TransactionState state);
        _publishEndpointMock
            .Verify(publishEndpoint => publishEndpoint.Publish(It.IsAny<PaymentStatusUpdated>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [When("listing all transaction with status '(.*)' the result list should have '(.*)' elements")]
    public async Task WhenListingAllTransactionWithStatus(string expectedState, int expectedCount)
    {
        Enum.TryParse(expectedState, out TransactionState state);
        var listPaymentByStateRequest = new ListPaymentByStateRequest(state);

        var transactions = await _listPaymentUseCase.ExecuteAsync(listPaymentByStateRequest);
        transactions
            .Should()
            .NotBeNull()
            .And
            .HaveCount(expectedCount);
    }
}