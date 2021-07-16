using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.DTO;
using Aisoftware.Tracker.Borders.Users.Requests;
using Aisoftware.Tracker.UseCases.Login.Interfaces;

namespace Aisoftware.Tracker.UseCases.Login.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILoginUseRepository _repository;

        public LoginUseCase(ILoginUseRepository repository)
        {
            _repository = repository;
        }
        public Task<UserDTO> Login(UserRequest request)
        {
            var user = await _repository.Login(request);

            //var dto = Mapper().Map<UserDTO>(user);

        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
