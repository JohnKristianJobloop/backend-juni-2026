using core.Services.Builders;
using core.Services.Extensions;

namespace webapi.models.dto;

public static class NewRepairFormExtension
{
    extension(NewRepairFormDto dto)
    {
        public core.Models.IResult BuildForm()
        {
            var builder = new NewRepairFormResultBuilder();
            return builder.WithName(dto.CustomerName).WithCarBrand(dto.CarModel).WithRepairType(dto.RepairType).Build();
        }
    }
}