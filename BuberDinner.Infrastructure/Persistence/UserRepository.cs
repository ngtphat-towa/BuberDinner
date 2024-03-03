using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Users;


namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public async Task AddUserAsync(User user)
    {
        await Task.CompletedTask;
        _users.Add(user);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(u => u.Email == email);
    }
}