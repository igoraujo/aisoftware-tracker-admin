using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.UseCases.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.Admin.CodeBehind
{
    public class Auth
    {
        private readonly string TOKEN_REMEMBER = "tokenremember";
        private readonly string TOKEN = "token";
        private readonly string YES = "S";

        private AisoftwareTrackerCodeBehind _moviyCode;
        private HandlerFactory _handlerFactory;

        public Auth(AisoftwareTrackerCodeBehind moviyCode, HandlerFactory handlerFactory)
        {
            _moviyCode = moviyCode;
            _handlerFactory = handlerFactory;
        }

        public string _login = string.Empty;

        public bool IsLogged()
        {
            return !string.IsNullOrEmpty(Token);
        }

        private User _user = null;

        public User UsuarioLogado
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

        public async Task<bool> Login(string ip, string user, string password, bool isRemember)
        {
            var loguei = _handlerFactory.User.Logar(user, password);
            if (loguei != null)
            {
                TokenRemember = isRemember; //Colocar esse primeiro, pq os proximos usam esse valor
                _login = loguei.Email;
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
            _login = string.Empty;
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
