using System.Threading.Tasks;
using Aisoftware.Tracker.Borders.Users.Entities;
using Aisoftware.Tracker.Borders.Users.Requests;
using Aisoftware.Tracker.Repositories.Login.Interfaces;

namespace Aisoftware.Tracker.Repositories.Login.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        public LoginRepository()
        {

        }

        public Task<User> Login(UserRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}