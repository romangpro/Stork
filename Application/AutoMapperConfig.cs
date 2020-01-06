using Application.Sports;
using AutoMapper;
using Domain.Sports;

namespace Application
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg => {
                //cfg.CreateMap<Foo, Bar>();
                //cfg.AddProfile<FooProfile>();
                cfg.AddMaps(typeof(CreateLeagueProfile).Assembly);
            });
            return config;
        }
    }
}
