using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Register
{
    public interface IRegister
    {
        void Register(IServiceCollection services, IConfiguration config);
    }

    //foreach(var register in Assembly.GetExecutingAssembly().ExportedTypes
    //    .Where(x => typeof(IRegister).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
    //    .Select(Activator.CreateInstance).Cast<IRegister>())
    //{
    //    register.Register(services, Configuration);
    //}
    //services.AddSingleton<CreateLeagueValidator, CreateLeagueValidator>();
}
