using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
    {
        return Created("", await Mediator.Send(command));
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
    {
        return Created("", await Mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetList()
    {
        return Created("", await Mediator.Send(new GetListBrandQuery()));
    }

    [HttpPost("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdBrandQuery query)
    {
        return Created("", await Mediator.Send(query));
    }
}
