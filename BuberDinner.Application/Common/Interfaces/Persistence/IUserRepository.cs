
using BuberDinner.Domain.Users;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
}