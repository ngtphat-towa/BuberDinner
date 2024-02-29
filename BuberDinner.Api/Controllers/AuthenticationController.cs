using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = await authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        return authResult.Match(authenticationResult => Ok(
            MapAuthResult(authenticationResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = await authenticationService.Login(request.Email, request.Password);
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