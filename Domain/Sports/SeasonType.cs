namespace Domain.Sports
{
    public enum GameType : ushort
    {
        Training = 1, //can overlap
        PreSeason = 2,
        Regular = 3,
        Playoff = 4
    }
}
