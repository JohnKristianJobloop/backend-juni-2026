using core.Repositories;
using webapi.groups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<RepairRepository>();

var app = builder.Build();

// Configure the HTTP request pipelin
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapRepairFormGroup();

app.Run();
