using core.Models;

namespace core.Services.Builders;


/// <summary>
/// Fluent builder for constructing a validated <see cref="NewRepairForm"/>.
/// Each method extends <see cref="IResult"/>, following the railway-oriented programming pattern:
/// a <see cref="Success{T}"/> advances to the next step, while an <see cref="Error"/>
/// short-circuits the rest of the chain and is passed through unchanged.
/// Start the chain with <c>new Success&lt;NewRepairForm&gt;(new NewRepairForm())</c>.
/// </summary>
public static class NewRepairFormResultBuilder
{
    private static readonly string[] ValidRepairTypes =
    [
        "Oil change", "Tire change", "Bodywork", "Brake replacement", "Paint repair",
        "Engine service", "Battery", "Transmission", "Cooling system", "Exhaust repair",
        "Bulb replacement", "Air filter", "Shock absorber", "Wiper blades"
    ];

    private static readonly string[] ValidCarBrands =
    [
        "Ford", "Toyota", "Opel", "VW", "Honda", "BMW", "Mercedes", "Audi",
        "Volvo", "Peugeot", "Renault", "Citroën", "Hyundai", "Kia", "Nissan",
        "Mazda", "Subaru", "Fiat", "Seat", "Škoda", "Mitsubishi", "Tesla", "Lexus"
    ];
    /// <summary>
    /// Assigns an ID to the form. If no ID is provided, a new <see cref="Guid"/> is generated.
    /// </summary>
    /// <param name="option">The current state of the build chain.</param>
    /// <param name="id">Optional explicit ID. Omit to let the server assign one.</param>
    public static IResult BindId(this IResult result, Guid? id = null) =>
    result is Success<NewRepairForm> success 
        ? new Success<NewRepairForm>(success.Value with {Id = id ?? Guid.NewGuid()})
        : result;
    /// <summary>
    /// Sets the customer name. Returns <see cref="Error"/> if the value is null, whitespace,
    /// or shorter than 2 characters.
    /// </summary>
    /// <param name="option">The current state of the build chain.</param>
    /// <param name="customer">The customer name to validate and assign.</param>
    public static IResult BindCustomer(this IResult result, string? customer) => 
    result is Success<NewRepairForm> success
        ? string.IsNullOrWhiteSpace(customer)
            ? new Error("Missing Customer name")
            : customer.Length < 2
             ? new Error("Name must contain more than two characters")
             : new Success<NewRepairForm>(success.Value with {CustomerName = customer})
    : result;

    /// <summary>
    /// Sets the repair type. Returns <see cref="Error"/> if the value is not in the list of
    /// accepted repair types. Comparison is case-insensitive.
    /// </summary>
    /// <param name="option">The current state of the build chain.</param>
    /// <param name="repairType">The requested repair type to validate and assign.</param>
    public static IResult BindValidRepairType(this IResult result, string? repairType) =>
        result is Success<NewRepairForm> success 
            ?   (!string.IsNullOrWhiteSpace(repairType) && ValidRepairTypes.Contains(repairType, StringComparer.InvariantCultureIgnoreCase))
                ? new Success<NewRepairForm>(success.Value with {RepairType = repairType})
                : new Error($"{repairType} is covered by this workshop")
            : result;
            
    /// <summary>
    /// Sets the car brand. Returns <see cref="Error"/> if the value is not in the list of
    /// accepted brands. Comparison is case-insensitive.
    /// </summary>
    /// <param name="option">The current state of the build chain.</param>
    /// <param name="brand">The car brand to validate and assign.</param>           
    public static IResult BindValidCarBrand(this IResult result, string? brand) =>
        result is Success<NewRepairForm> success 
            ?   (!string.IsNullOrWhiteSpace(brand) && ValidCarBrands.Contains(brand, StringComparer.InvariantCultureIgnoreCase))
                ? new Success<NewRepairForm>(success.Value with {CarModel = brand})
                : new Error($"{brand} is covered by this workshop")
            : result;

}