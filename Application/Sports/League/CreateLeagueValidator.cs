using FluentValidation;

namespace Application.Sports
{
    public class CreateLeagueValidator : NameAbbrValidator<CreateLeagueCommand>
    {
        public CreateLeagueValidator()
        {
            RuleFor(x => x.LeagueLocation).IsInEnum();
            RuleFor(x => x.Sex).IsInEnum();
            RuleFor(x => x.Sport).IsInEnum();
        }
    }
}
