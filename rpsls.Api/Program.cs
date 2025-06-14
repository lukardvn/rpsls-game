using rpsls.Api;
using rpsls.Api.Endpoints;
using rpsls.Application;
using rpsls.Domain;
using rpsls.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApiServices();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterDomainServices();
builder.Services.RegisterInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterGameEndpoints();

app.Run();