using FluentValidation;

namespace SchoolHive.Modules.Users.Application.Users.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty().WithMessage($"{nameof(RegisterUserCommand.FirstName)} cannot be null");
            RuleFor(o => o.FirstName).MinimumLength(3).WithMessage($"{nameof(RegisterUserCommand.FirstName)} should be must minumum 3 chracters");
        }
    }
}
