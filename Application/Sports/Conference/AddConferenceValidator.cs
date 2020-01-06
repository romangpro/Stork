using FluentValidation;

namespace Application.Sports
{
    public class AddConferenceValidator : NameAbbrValidator<AddConferenceCommand>
    {
        public AddConferenceValidator()
        {
            RuleFor(x => x.LeagueId).NotNull();
        }
    }
}
