using core.Models;
using core.Services.Builders;
using core.Services.Extensions;

namespace webapi.models.dto;

public class NewRepairFormDto
{
    public string CustomerName {get;set;} = "";
    public string CarModel {get;set;} = "";
    public string RepairType {get;set;} = "";
}