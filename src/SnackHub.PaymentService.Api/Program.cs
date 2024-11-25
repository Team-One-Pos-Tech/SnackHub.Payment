using System.Text.Json.Serialization;
using SnackHub.PaymentService.Api.Endpoints.Payment;
using SnackHub.PaymentService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder
    .Services
    .AddDatabaseContext(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddRepositories()
    .AddUseCases();

var app = builder.Build();
app.AddPaymentEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
