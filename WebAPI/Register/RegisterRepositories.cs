using Application.Interfaces;
using Infrastructure.Sports;
using Infrastructure.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Register
{
    public class RegisterRepositories : IRegister
    {
        public readonly ServiceLifetime Lifetime = ServiceLifetime.Scoped;
        public RegisterRepositories() { }

        public void Register(IServiceCollection services, IConfiguration config)
        {            
            //TODO: should get the namespace from config
     
            //var r1 = new LeagueRepository();
            //services.AddSingleton(typeof(IRepository<League>), r1);
            services.AddScoped(typeof(ILeagueRepository), typeof(LeagueRepository));

            //var r2 = new UserRepository();
            //services.AddSingleton(typeof(IRepository<User>), r2);
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            //services.Add(new ServiceDescriptor(kvp.RegisterInterface, kvp.Type, lifetime));
            //services.RegisterAllTypes(typeof(IRepository<>), namespace2: "InMemory", assemblies: new[] { typeof(LeagueRepository).Assembly }, lifetime: ServiceLifetime.Singleton);
        }
    }
}
