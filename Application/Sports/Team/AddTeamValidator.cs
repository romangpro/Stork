using Domain.Sports;
using FluentValidation;

namespace Application.Sports
{
    public class AddTeamValidator : NameAbbrValidator<AddTeamCommand>
    {
        public AddTeamValidator(League league)
        {
            RuleFor(x => x).Must((cmd, tok) =>
            {
                return league.Teams.UniqueNameAbbr(cmd);
            });
        }
    }
}
