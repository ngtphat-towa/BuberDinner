using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Commons.Errors;
using BuberDinner.Domain.Entities;

using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    public async Task<ErrorOr<AuthenticationResult>> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exit
        if (await userRepository.GetUserByEmailAsync(email) is not null)
        {
            return ErrorsFactory.User.DuplicateEmail;
        }
        // 2. Create User (Guid) id
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await userRepository.AddUserAsync(user);
        // 3. Create Jwt token
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password)
    {
        // 1. Validate user exists
        if (await userRepository.GetUserByEmailAsync(email) is not User user)
        {
            return ErrorsFactory.Authentication.NotFoundEmail;
        }
        // 2. Validate password is correct
        // TODO: implement hasing password
        if (user.Password != password)
        {
            return ErrorsFactory.Authentication.InvalidCredentials;
        }
        // 3. Create Jwt token
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}