using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateModelCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateModelCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteModelCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetList()
    {
        return Created("", await Mediator.Send(new GetListModelQuery()));
    }

    [HttpPost("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdModelQuery query)
    {
        return Created("", await Mediator.Send(query));
    }
}
