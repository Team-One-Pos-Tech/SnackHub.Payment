using SnackHub.Payment.Api.Endpoints.Customer;
using SnackHub.Payment.Api.Endpoints.Payment;
using SnackHub.Payment.Domain;
using SnackHub.Payment.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.AddSingleton<Settings>(builder.Configuration.GetSection("Settings").Get<Settings>()!);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMainProject(builder.Configuration);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://snackhubpaymentdev.kallesoft.com.br/",
                                              "https://snackhubadmindev.kallesoft.com.br/");
                      });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.AddCustomerEndpoints();
app.AddPaymentEndpoints();
app.Run();
