using System;

namespace Domain.Sports
{
    [Flags]
    public enum LeagueLocation : short
    {
        USA = 1 << 0,
        Canada = 1 << 1,
        France = 1 << 2,
        Germany = 1 << 3,
        Italy = 1 << 4,
        UK = 1 << 5,
        Russia = 1 << 6,
        Sweden = 1 << 7,
        CanadaUSA = USA | Canada,
        EU = France | Germany | Italy | Sweden
    }
}
