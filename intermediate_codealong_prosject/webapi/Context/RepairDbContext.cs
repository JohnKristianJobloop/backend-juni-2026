using core.Interfaces;
using core.Models;
using Microsoft.EntityFrameworkCore;
using webapi.models.entity;
using IResult = core.Models.IResult;

namespace webapi.Context;


public class RepairDbContext(DbContextOptions<RepairDbContext> options) : DbContext(options), IAsyncRepairRepository
{

    public DbSet<RepairForm> NewRepairForms => Set<RepairForm>();

    public async Task<IResult> FindByIdAsync(Guid id)
    {
        var result = await NewRepairForms.FirstOrDefaultAsync(i => i.Id == id);
        return result is null ? new Error($"No item with id {id}") : new Success<NewRepairForm>( new (result.Id, result.CustomerName, result.CarModel, result.RepairType));
    }

    public async Task<IReadOnlyList<NewRepairForm>> GetAllAsync()
    {
        return [..NewRepairForms.Select(r => new NewRepairForm(r.Id, r.CustomerName, r.CarModel, r.RepairType))];
    }

    public async Task<NewRepairForm> SaveAsync(NewRepairForm form)
    {
        var obj = new RepairForm
        {
            Id = form.Id,
            CustomerName = form.CustomerName,
            CarModel = form.CarModel,
            RepairType = form.RepairType
        };
        NewRepairForms.Add(obj);
        await SaveChangesAsync();
        return form;
    }
}