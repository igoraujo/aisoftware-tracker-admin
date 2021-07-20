using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.DTO;
using Aisoftware.Tracker.Borders.Users.Requests;
using Aisoftware.Tracker.UseCases.Login.Interfaces;
using Aisoftware.Tracker.Repositories.Login.Interfaces;

namespace Aisoftware.Tracker.UseCases.Login.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILoginRepository _repository;

        public LoginUseCase(ILoginRepository repository)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<UserDTO> Login(UserRequest request)
        {
            var user = await _repository.Login(request);

            // var dto = Mapper().Map<UserDTO>(user);
            throw new System.NotImplementedException();
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
