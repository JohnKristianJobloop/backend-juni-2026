using core.Models;
using core.Repositories;
using core.Services.Builders;

namespace console.Services;


/// <summary>
/// Orchestrates interactive creation of a <see cref="NewRepairForm"/> via console prompts.
/// On validation failure the user is re-prompted up to <c>MaxRetries</c> times before
/// returning an <see cref="Error"/>.
/// </summary>
/// <param name="repository">The repository used to persist successfully validated forms.</param>
public class NewRepairFormConsoleService(RepairRepository repository)
{
    private const int MaxRetries = 3;

    /// <summary>
    /// Builds a form by prompting the user for each required field and running the
    /// railway-oriented validation chain from <c>NewRepairFormResultBuilder</c>.
    /// </summary>
    private IResult GenerateForm() =>
        new Success<NewRepairForm>(new NewRepairForm())
        .BindId()
        .BindCustomer(InputService.WithPrompt("What is your name?"))
        .BindValidRepairType(InputService.WithPrompt("What repair do you want?"))
        .BindValidCarBrand(InputService.WithPrompt("What is you car model?"));
    
    /// <summary>
    /// Persists the validated form to the repository and returns the same
    /// <see cref="Success{T}"/> to the caller.
    /// </summary>
    /// <param name="success">The successful result containing the completed form.</param>
    private IResult SaveAndReturn(Success<NewRepairForm> success)
    {
        repository.Save(success.Value);
        return success;
    }

    /// <summary>
    /// Prints the validation error and retries form creation if attempts remain;
    /// otherwise returns the <see cref="Error"/> to the caller.
    /// </summary>
    /// <param name="error">The validation error from the previous attempt.</param>
    /// <param name="retriesLeft">Number of remaining attempts.</param>
    private IResult CreateFormWithError(Error err, int retriesLeft)
    {
        Console.WriteLine(err.Message);
        return retriesLeft > 0 ? CreateForm(retriesLeft - 1) : err;
    }

    /// <summary>
    /// Prompts the user to fill in a repair form, retrying on validation errors.
    /// Returns <see cref="Success{T}"/> with the saved form, or <see cref="Error"/>
    /// after all retries are exhausted.
    /// </summary>
    /// <param name="retriesLeft">Maximum number of re-prompt attempts. Defaults to <c>MaxRetries</c>.</param>
    public IResult CreateForm(int retriesLeft = MaxRetries)
    {
        var form = GenerateForm();
        return form switch
        {
            Success<NewRepairForm> success => SaveAndReturn(success),
            Error err => CreateFormWithError(err, retriesLeft),
            _ => throw new NotSupportedException("Datatype is not of supported type")
        };
    }
}