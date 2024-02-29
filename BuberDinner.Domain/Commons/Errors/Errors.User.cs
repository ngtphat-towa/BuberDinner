using ErrorOr;

namespace BuberDinner.Domain.Commons.Errors;

public static partial class ErrorsFactory
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");
    }
}