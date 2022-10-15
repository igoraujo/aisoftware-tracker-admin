using Aisoftware.Tracker.Repositories.Sessions.Repositories;
using Aisoftware.Tracker.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.UseCases.Sessions.UseCases
{
    public class SessionUseCase : ISessionUseCase
    {
        private readonly ISessionRepository _repository;

        public SessionUseCase(ISessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Session> Find(string cookieValue)
        {
            return await _repository.Find(cookieValue);
        }

        public async Task<Session> Create(Login login, string cookieValue)
        {
            var request = new Dictionary<string, string>
            {
                {"email", login.Email},
                {"password", login.Password}
            };

            return await _repository.Create(request, cookieValue);
        }

        public async Task Delete(string cookieValue)
        {
            await _repository.Delete(cookieValue);
        }

        public string GetCookieValue()
        {
            return _repository.GetCookie().Value;
        }

    }
}
