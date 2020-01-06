using Domain.Users;
using FluentValidation;

namespace Application.Users
{
    public class RegisterUserValidator
        : AbstractValidator<RegisterUserCommand>
    {
        public static int MaxStringLength = 50;

        public RegisterUserValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(MaxStringLength);
            //TODO: regex
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(MaxStringLength).Must(x => x.Contains("@") && x.Contains("."));
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(MaxStringLength);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(MaxStringLength);
        }
    }
}
