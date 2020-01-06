using FluentValidation;

namespace Application
{
    public class NameAbbrValidator<T> : AbstractValidator<T> where T: NameAbbrCommand
    {
        public static int NAME_LENGTH = 50;
        public static int ABBR_LENGTH = 5;
        public NameAbbrValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(NAME_LENGTH);
            RuleFor(x => x.Abbr).NotNull().NotEmpty().MaximumLength(ABBR_LENGTH);
        }
    }
}
