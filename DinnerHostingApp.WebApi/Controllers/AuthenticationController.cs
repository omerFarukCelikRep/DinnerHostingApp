using DinnerHostingApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using DinnerHostingApp.Domain.Common;
using MediatR;
using DinnerHostingApp.Application.Authentication.Commands.Register;
using DinnerHostingApp.Application.Authentication.Common;
using DinnerHostingApp.Application.Authentication.Queries.Login;

namespace DinnerHostingApp.WebApi.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = new RegisterCommand(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = new LoginQuery(loginRequest.Email, loginRequest.Password);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
    }
}
