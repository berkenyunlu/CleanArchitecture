using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Name).Empty().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("{PropertyName} en az 3 karakter olmalıdır.");

        RuleFor(p => p.Model).Empty().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.Model).NotNull().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.Model).MinimumLength(3).WithMessage("{PropertyName} en az 3 karakter olmalıdır.");

        RuleFor(p => p.EnginePower).Empty().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.EnginePower).NotNull().WithMessage("{PropertyName} boş olamaz.");
        RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("{PropertyName} 0 dan büyük olmalıdır.");
    }
}