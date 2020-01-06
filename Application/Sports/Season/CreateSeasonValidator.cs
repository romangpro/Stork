using Application.Interfaces;
using FluentValidation;

namespace Application.Sports
{
    public class CreateSeasonValidator : AbstractValidator<CreateSeasonCommand>
    {
        private readonly ILeagueRepository _repo;

        public CreateSeasonValidator(ILeagueRepository repo)
        {
            _repo = repo;
            RuleFor(x => x).MustAsync(async (cmd, tok) =>
            {
                var league = await _repo.GetAsync(cmd.LeagueId);
                if (league == null)
                    return false;
                return true;
                //return league.Teams.UniqueNameAbbr(cmd);
            });
        }
    }
}
