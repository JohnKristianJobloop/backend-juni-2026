using core.Models;

namespace core.Interfaces;

public interface IRepairRepository
{
    void Save(NewRepairForm form);
    IReadOnlyList<NewRepairForm> GetAll();

    IResult FindById(Guid id);
}