using ErrorOr;

using FluentValidation;

using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // If there's no validator configured, skip validation and proceed to the next step:
        if (_validator is null)
        {
            return await next();
        }

        // Perform validation using FluentValidation's ValidateAsync method
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        // If validation passes, call the next delegate to continue processing:
        if (validationResult.IsValid)
        {
            return await next();
        }
        // If validation fails, extract the errors and prepare them for the response:
        var errors = validationResult.Errors.ConvertAll(
            validationFailure =>
            Error.Validation(validationFailure.PropertyName,
                             validationFailure.ErrorMessage));

        // Note: This is the way to go around reflection
        return (dynamic)errors;
    }
}