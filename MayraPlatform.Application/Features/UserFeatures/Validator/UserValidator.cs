using MayraPlatform.Application.Features.UserFeatures.CreateUser;
using MayraPlatform.Application.Features.UserFeatures.UpdateUser;
using FluentValidation;

namespace MayraPlatform.Application.Features.UserFeatures.Validator;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.LastName).MaximumLength(50);
    }
}

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(50);
    }
}