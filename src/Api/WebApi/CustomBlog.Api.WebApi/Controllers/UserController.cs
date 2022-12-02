using CustomBlog.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CustomBlog.Api.WebApi.Controllers;
[Route("api/[Controller]")]
[ApiController]

public class UserController : Controller
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var res = await mediator.Send(command);

        return Ok(res);
    }
}
