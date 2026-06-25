using core.Interfaces;
using core.Models;

namespace core.Repositories;

/// <summary>
/// In-memory store for <see cref="NewRepairForm"/> instances.
/// </summary>
public class RepairRepository : IRepairRepository
{

    private readonly List<NewRepairForm> _forms = [];

    /// <summary>
    /// Persists a completed repair order.
    /// </summary>
    /// <param name="form">The validated form to store.</param>
    public NewRepairForm Save(NewRepairForm form){
        _forms.Add(form);
        return form;
    }

    /// <summary>
    /// Returns all stored repair orders as a read-only list.
    /// An IReadOnly lists ensures no outside call can manipulate or change the elements of _forms directly. 
    /// </summary>
    public IReadOnlyList<NewRepairForm> GetAll() => _forms;

    /// <summary>
    /// Looks up a repair order by its ID. Returns <see cref="Success{T}"/> if found,
    /// or <see cref="Error"/> if no order with that ID exists. This is a natural fit
    /// for <see cref="IResult"/>, a lookup can genuinely fail without it being exceptional.
    /// </summary>
    /// <param name="id">The ID of the repair order to retrieve.</param>
    public IResult FindById(Guid id)
    {
        var form = _forms.FirstOrDefault(f => f.Id == id);
        return form is null
        ? new Error($"No form with id {id}")
        : new Success<NewRepairForm>(form);
        
    }
}