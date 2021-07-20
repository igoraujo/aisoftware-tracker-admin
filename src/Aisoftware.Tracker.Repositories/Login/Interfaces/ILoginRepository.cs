using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.Entities;
using Aisoftware.Tracker.Borders.Users.Requests;

namespace Aisoftware.Tracker.Repositories.Login.Interfaces
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <returns>
        /// return user (session)
        /// </returns>
        Task<User> Login(UserRequest request);
        Task Logout();
    }
}