using core.Models;
using core.Services.Extensions;

namespace core.Services.Builders;

public class NewRepairFormResultBuilder
{
    public IResult Result;

    public NewRepairFormResultBuilder(){
        Result = new Success<NewRepairForm>(new NewRepairForm()).BindId();
    }
    
}