namespace core.Models;

/// <summary>
/// Immutable data model representing a repair order.
/// Constructed incrementally via <c>NewRepairFormBuilder</c>. Each step
/// validates one field and returns a new instance, leaving the original unchanged.
/// </summary>
/// <param name="Id">Unique identifier for the repair order. Assigned server-side.</param>
/// <param name="CustomerName">Full name of the customer submitting the order.</param>
/// <param name="CarModel">The car brand being serviced.</param>
/// <param name="RepairType">The type of repair requested.</param>
public record NewRepairForm(
    Guid Id = default,
    string CustomerName = default!,
    string CarModel = default!,
    string RepairType = default!
)
{
    /// <summary>
    /// Returns a single-line summary of the repair order.
    /// Functions similar to python's to_string when printing an object. 
    /// </summary>
    public override string ToString()
    {
        return $"Id = {Id}, Name = {CustomerName}, Car = {CarModel}, RepairType = {RepairType}";
    }
}