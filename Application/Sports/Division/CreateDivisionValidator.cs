using FluentValidation;

namespace Application.Sports
{
    public class CreateDivisionValidator : NameAbbrValidator<CreateDivisionCommand>
    {
        public CreateDivisionValidator()
        {
            RuleFor(x => x.LeagueId).NotNull();
        }
    }
}
