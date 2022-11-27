using DinnerHostingApp.Application.Menus.Create;
using DinnerHostingApp.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHostingApp.WebApi.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>(request);

        var createMenuResult = await _mediator.Send(command);
        //return createMenuResult.Match(
        //    menu => CreatedAtAction(nameof(Get), new { hostId, menuId = menu.Id }, menu),
        //    errors => Problem(errors));

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }
}