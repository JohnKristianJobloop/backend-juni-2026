using core.Models;
using core.Services.Builders;

namespace core.Services.Extensions;

public static class NewRepairFormResultBuilderExtensions
{
    public static NewRepairFormResultBuilder WithName(this NewRepairFormResultBuilder builder, string name)
    {
        builder.Result = builder.Result.BindCustomer(name);
        return builder;
    }

    public static NewRepairFormResultBuilder WithCarBrand(this NewRepairFormResultBuilder builder, string carBrand)
    {
        builder.Result = builder.Result.BindValidCarBrand(carBrand);
        return builder;
    }

    public static NewRepairFormResultBuilder WithRepairType(this NewRepairFormResultBuilder builder, string repairType)
    {
        builder.Result = builder.Result.BindValidRepairType(repairType);
        return builder;
    }
    public static IResult Build(this NewRepairFormResultBuilder builder) => builder.Result;
}