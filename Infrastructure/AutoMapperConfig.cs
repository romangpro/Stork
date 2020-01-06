using AutoMapper;
using Infrastructure.Sports;

namespace Infrastructure
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            //cfg.CreateMap<LeagueDao, League>();
            //cfg.AddProfile<FooProfile>();
            cfg.AddMaps(typeof(LeagueDao));
        });
    }
}
