using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        await Task.CompletedTask;
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        await Task.CompletedTask;
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, "firstName", "lastName");
        return new AuthenticationResult(userId, "firstName", "lastName", email, token);
    }
}