using core.Models;
using core.Services.Extensions;

public class FormResultBuilderTests
{
    [Fact]
    public void FormBuilder_WithValidStringsInAllSteps_ReturnSuccessWithFormObject()
    {
        var result = new Success<NewRepairForm>(new NewRepairForm())
            .BindId()
            .BindCustomer("John")
            .BindValidCarBrand("Volvo")
            .BindValidRepairType("Oil change");

        Assert.IsType<Success<NewRepairForm>>(result);
        var success = result as Success<NewRepairForm>;
        Assert.NotNull(success);
        Assert.IsType<NewRepairForm>(success.Value);
    }

    [Fact]
    public void FormBuilder_WithMissingCustomerName_ReturnsErrorWithMissingNameMessage()
    {
        var result = new Success<NewRepairForm>(new NewRepairForm())
            .BindId()
            .BindCustomer("")
            .BindValidCarBrand("Volvo")
            .BindValidRepairType("Oil change");

        Assert.IsType<Error>(result);
        var error = result as Error;
        Assert.NotNull(error);
        Assert.Equal("Missing Customer name", error.Message);
    }

    [Fact]
    public void FormBuilder_WithInvalidCustomerName_ReturnsErrorWithInvalidNameMessage()
    {
        var result = new Success<NewRepairForm>(new NewRepairForm())
            .BindId()
            .BindCustomer("J")
            .BindValidCarBrand("Volvo")
            .BindValidRepairType("Oil change");

        Assert.IsType<Error>(result);
        var error = result as Error;
        Assert.NotNull(error);
        Assert.Equal("Name must contain more than two characters", error.Message);
    }

    [Fact]
    public void FormBuilder_WithInvalidCarBrand_ReturnsErrorWithNotSupportedMessage()
    {
        var result = new Success<NewRepairForm>(new NewRepairForm())
            .BindId()
            .BindCustomer("John")
            .BindValidCarBrand("Maserati")
            .BindValidRepairType("Oil change");

        Assert.IsType<Error>(result);
        var error = result as Error;
        Assert.NotNull(error);
        Assert.Equal("Maserati is covered by this workshop", error.Message);
    }

    [Fact]
    public void FormBuilder_WithInvalidRepairType_ReturnsErrorWithNotSupportedMessage()
    {
        var result = new Success<NewRepairForm>(new NewRepairForm())
            .BindId()
            .BindCustomer("John")
            .BindValidCarBrand("Volvo")
            .BindValidRepairType("Flux capacitor refill");

        Assert.IsType<Error>(result);
        var error = result as Error;
        Assert.NotNull(error);
        Assert.Equal("Flux capacitor refill is not covered by this workshop", error.Message);
    }
}