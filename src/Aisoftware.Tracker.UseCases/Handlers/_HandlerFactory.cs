using Aisoftware.Tracker.Borders.Users.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class HandlerFactory : IDisposable
    {
        public static IHostingEnvironment Environment;

        private IOptions<Config> _config;

        private UserDTO user;
        
        private string _userIP;
        public string UserIP
        {
            get
            {
                return _userIP;
            }
            set
            {
                if (_config != null)
                    _config.Value.UserIP = value;

                _userIP = value;
            }
        }

        public UserDTO User { get => user; set => user = value; }

        public void Dispose()
        {

        }
    }
}