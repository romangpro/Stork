using Application.Sports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Register
{
    public class RegisterServices : IRegister
    {
        public readonly ServiceLifetime Lifetime = ServiceLifetime.Scoped;
        public RegisterServices() { }

        public void Register(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ILeagueService, LeagueService>();
        }
    }
}
