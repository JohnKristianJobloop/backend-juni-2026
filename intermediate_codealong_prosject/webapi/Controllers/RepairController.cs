using core.Interfaces;
using core.Models;
using core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.models.dto;

namespace webapi.Controllers;

[Route("/[controller]/")]
[ApiController]
public class RepairController(IAsyncRepairRepository repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<NewRepairForm>> GetAsync() => await repository.GetAllAsync();
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id) => await repository.FindByIdAsync(id) is Success<NewRepairForm> success ? Ok(success.Value) : NotFound();
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] NewRepairFormDto dto)
    {
        var result = dto.BuildForm();

        return result switch
        {
            Success<NewRepairForm> success => Created($"/repair/{success.Value.Id}", await repository.SaveAsync(success.Value)),
            Error error => BadRequest(new {message = error.Message}),
            _ => StatusCode(500, new {message = "Something went terribly wrong" })
        };
    }


}