using core.Models;
using core.Repositories;
using Microsoft.AspNetCore.Mvc;
using webapi.models.dto;

namespace webapi.groups;

public static class RepairFormMapGroups
{
    extension (WebApplication app)
    {
        public WebApplication MapRepairFormGroup()
        {
            var group = app.MapGroup("/repair");

            group.MapGet("/", ( RepairRepository repository ) => repository.GetAll());

            group.MapGet("/{id:guid}", (RepairRepository repository, Guid id) => repository.FindById(id) is Success<NewRepairForm> success ? Results.Ok(success.Value) : Results.NotFound());

            group.MapPost("/", (RepairRepository repository, [FromBody] NewRepairFormDto dto) =>
            {
                var result = dto.BuildForm();
                switch (result)
                {
                    case Error error:
                        return Results.BadRequest(error.Message);
                    case Success<NewRepairForm> success:
                        repository.Save(success.Value);
                        return Results.Created($"/{success.Value.Id}", success.Value);
                    default:
                        return Results.InternalServerError();
                }
            });


            return app;
        }
    }
}