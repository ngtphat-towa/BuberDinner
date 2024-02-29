using ErrorOr;

namespace BuberDinner.Domain.Commons.Errors;

public static partial class ErrorsFactory
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");

        public static Error NotFoundEmail => Error.NotFound(
            code: "Auth.NotFoundEmail",
            description: "Email doesn't exist");
    }
}