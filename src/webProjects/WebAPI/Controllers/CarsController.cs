using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Features.Cars.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCarCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetList()
    {
        return Created("", await Mediator.Send(new GetListCarQuery()));
    }

    [HttpPost("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdCarQuery query)
    {
        return Created("", await Mediator.Send(query));
    }

    [HttpGet("Pagination")]
    public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
    {
        GetListPaginationCarQuery query = new() { PageRequest = pageRequest };
        CarListModel result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListCarDynamicQuery carDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        CarListModel result = await Mediator.Send(carDynamicQuery);
        return Ok(result);
    }
}
