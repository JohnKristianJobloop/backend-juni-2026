using core.Interfaces;
using core.Repositories;
using webapi.groups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepairRepository, RepairRepository>();

var app = builder.Build();

// Configure the HTTP request pipelin
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapFallbackToFile("index.html");
app.MapControllers();


//app.MapRepairFormGroup();

app.Run();
