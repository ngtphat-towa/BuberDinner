using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Commons.Errors;
using BuberDinner.Domain.Users;


using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken = default)
    {
        // 1. Validate user exists
        if (await _userRepository.GetUserByEmailAsync(query.Email) is not User user)
        {
            return ErrorsFactory.Authentication.NotFoundEmail;
        }
        // 2. Validate password is correct
        // TODO: implement hasing password
        if (user.Password != query.Password)
        {
            return ErrorsFactory.Authentication.InvalidCredentials;
        }
        // 3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}