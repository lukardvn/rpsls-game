using FluentValidation;
using MediatR;
using rpsls.Application.Exceptions;
using rpsls.Application.Messaging;
using ValidationException = rpsls.Application.Exceptions.ValidationException;

namespace rpsls.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken ct)
    {
        var context = new ValidationContext<TRequest>(request);

        var errors = _validators.Select(validator => validator.Validate(context))
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(validationFailure.PropertyName, validationFailure.ErrorMessage))
            .ToList();

        if (errors.Any())
            throw new ValidationException(errors);
        
        var response = await next(ct);

        return response;
    }
}