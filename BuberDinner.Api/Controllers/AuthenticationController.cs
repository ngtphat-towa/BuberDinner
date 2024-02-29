
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var commands = new RegisterCommand(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(commands);
        return authResult.Match(authenticationResult => Ok(
            MapAuthResult(authenticationResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(authenticationResult => Ok(
                MapAuthResult(authenticationResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }
}