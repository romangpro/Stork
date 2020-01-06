using Domain.Users;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        //UserId Login(string username, string password);
        //void ResetPassword(string username);
    }
}
