// See https://aka.ms/new-console-template for more information
using console.Services;
using core.Models;
using core.Repositories;

var repository = new RepairRepository();
var service = new NewRepairFormConsoleService(repository);

var result = service.CreateForm();

switch (result)
{
    case Error error:
        Console.WriteLine($"Failed to create order: {error.Message}");
        break;
    case Success<NewRepairForm> success:
        Console.WriteLine($"Order created: {success.Value}");
        break;
}