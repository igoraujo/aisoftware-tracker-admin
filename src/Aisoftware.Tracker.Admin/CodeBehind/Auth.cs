using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.Borders.Users.DTO;
using Aisoftware.Tracker.Borders.Users.Requests;
using Aisoftware.Tracker.Repositories.Login.Repositories;
using Aisoftware.Tracker.UseCases.Handlers;
using Aisoftware.Tracker.UseCases.Login.Interfaces;
using Aisoftware.Tracker.UseCases.Login.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.Admin.CodeBehind
{
    public class Auth
    {
        private readonly string TOKEN_REMEMBER = "tokenairsofttrack";
        private readonly string TOKEN = "token";
        private readonly string YES = "S";

        private AisoftwareTrackerCodeBehind _moviyCode;
        private HandlerFactory _handlerFactory;
        private readonly ILoginUseCase _login;

        public Auth(AisoftwareTrackerCodeBehind moviyCode, HandlerFactory handlerFactory)
        {
            _moviyCode = moviyCode;
            _handlerFactory = handlerFactory;
            ///TODO Corrigir
            _login = new LoginUseCase(new LoginRepository());
        }

        public string login = string.Empty;

        public bool IsLogged()
        {
            return !string.IsNullOrEmpty(Token);
        }

        private UserDTO _user = null;

        public UserDTO UsuarioLogado
        {
            get
            {
                if (_user == null && Token != Guid.Empty.ToString())
                {
                    _user = _handlerFactory.User.GetByToken(Token);
                }
                return _user;
            }
        }

        public async Task<bool> Login(string ip, string email, string password, bool isRemember)
        {
            var user = new UserRequest
            {
                Email = email,
                Password = password
            };

            var isLogin = _login.Login(user);

            var loguei = _handlerFactory.User.Logar(user, password);
            if (loguei != null)
            {
                TokenRemember = isRemember; //Colocar esse primeiro, pq os proximos usam esse valor
                login = loguei.Email;
                Token = loguei.Token.ToString();
                _user = loguei;
                return true;
            }
            else
                return false;
        }

        public void Logoff()
        {
            _user = null;
            TokenRemember = false;
            Token = null;
            login = string.Empty;
        }

        public bool TokenRemember
        {
            get
            {
                return _moviyCode.GetValue(TOKEN_REMEMBER) == YES;
            }
            set
            {
                _moviyCode.SaveValue(TOKEN_REMEMBER, value, null);
            }
        }
        public string Token
        {
            get
            {
                return _moviyCode.GetValue(TOKEN);
            }
            set
            {
                _moviyCode.SaveValue(TOKEN, value, null);
            }
        }
    }
}
