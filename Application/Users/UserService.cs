using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Users
{
    /// <summary>
    /// Dont need "factory", its to manage making complicated objects and abstract their creation if using flyweight pattern
    /// </summary>
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _repo;
        //private readonly IUserFactory _factory;
        public UserService(ILogger<UserService> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
            //_factory = factory;
        }

        //public Task RegisterUser(RegisterUserCommand cmd)
        //{
        //    var user = _factory.NewUser(cmd);
        //    return new Task();
        //}

        //public Task ResetPassword()
        //{

        //}

        //public Task EditUser()
        //{

        //}

        //public Task DeleteUser()
        //{

        //}
    }
}
