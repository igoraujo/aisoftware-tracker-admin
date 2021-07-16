using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.DTO;
using Aisoftware.Tracker.Borders.Users.Requests;

namespace Aisoftware.Tracker.UseCases.Login.Interfaces
{
    public interface ILoginUseCase
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <returns>
        /// return user (session)
        /// </returns>
        Task<UserDTO> Login(UserRequest request);
        Task Logout();
    }
}
