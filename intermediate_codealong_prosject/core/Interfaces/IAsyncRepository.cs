using core.Models;
namespace core.Interfaces;

public interface IAsyncRepairRepository
{
    Task<NewRepairForm> SaveAsync(NewRepairForm form);
    Task<IReadOnlyList<NewRepairForm>> GetAllAsync();

    Task<IResult> FindByIdAsync(Guid id);
}