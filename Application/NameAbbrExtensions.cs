using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    // cannot put this in NameAbbrValidator (generic all NameAbbr entity have unique Name, Abbr), 
    // because it might not be true, and could be in different context
    public static class NameAbbrExtensions
    {
        public static bool UniqueNameAbbr<TId>(this IEnumerable<NameAbbrEntity<TId>> entities, NameAbbrCommand cmd) where TId : Id
        {
            return !entities.Any(x => x.Name == cmd.Name || x.Abbr == cmd.Abbr);
        }
    }
}
