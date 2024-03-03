using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Commons.Errors;
using BuberDinner.Domain.Users;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken = default)
    {
        // 1. Validate the user doesn't exit
        if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
        {
            return ErrorsFactory.User.DuplicateEmail;
        }
        // 2. Create User (Guid) id
        var user = User.Create
        (
             command.FirstName,
             command.LastName,
             command.Email,
             command.Password
        );

        await _userRepository.AddUserAsync(user);
        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}