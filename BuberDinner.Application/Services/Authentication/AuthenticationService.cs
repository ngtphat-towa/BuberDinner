using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exit
        if (await _userRepository.GetUserByEmailAsync(email) is not null)
        {
            // TODO: Implement custom erorr handling
            throw new Exception("User with given name already exists!");
        }
        // 2. Create User (Guid) id
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate user exists
        if (await _userRepository.GetUserByEmailAsync(email) is not User user)
        {
            // TODO: Implement custom erorr handling
            throw new Exception("User with given credentail doesnt exits");
        }
        // 2. Validate password is correct
        // TODO: implement hasing password
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }
        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}