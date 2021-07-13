using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.DTO;

namespace Aisoftware.Tracker.UseCases.Session.Interfaces
{
    public interface ISessionUseCase
    {
        Task<UserDTO> Find(int id);
        Task<UserDTO> Find();
        Task<UserDTO> Save(UserDTO dto);

        /// <summary>
        /// Close the Session
        /// </summary>
        /// <returns>
        /// 204 - No Content
        /// </returns>
        Task Delete(UserDTO dto);
    }
}
