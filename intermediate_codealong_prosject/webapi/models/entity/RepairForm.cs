using System.ComponentModel.DataAnnotations;

namespace webapi.models.entity;

//POCO classe Plain Old CLR Object (Object med bare properties)
public class RepairForm
{
    [Key]
    public Guid Id {get;set;}
    public string CustomerName {get;set;} = "";
    public string RepairType {get;set;} = "";
    public string CarModel {get;set;} = "";
}