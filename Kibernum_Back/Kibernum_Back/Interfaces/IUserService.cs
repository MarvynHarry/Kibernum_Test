using Kibernum_Back.Models;

namespace Kibernum_Back.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(RegisterModel model);
    }
}
