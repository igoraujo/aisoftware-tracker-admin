using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.DTO;
using Aisoftware.Tracker.UseCases.Session.Interfaces;

namespace Aisoftware.Tracker.UseCases.Session.UseCases
{
    public class SessionUseCase : ISessionUseCase
    {
        public Task Delete(UserDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> Find()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> Save(UserDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
