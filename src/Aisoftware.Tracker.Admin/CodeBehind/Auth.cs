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

        private UserCompany _userCompany = null;

        public UserCompany UsuarioLogado
        {
            get
            {
                if (_userCompany == null && Token != Guid.Empty.ToString())
                {
                    _userCompany = _handlerFactory.UserCompany.GetByToken(Token);
                }
                return _userCompany;
            }
        }

        public async Task<bool> Login(string ip, string user, string password, bool isRemember)
        {
            var loguei = _handlerFactory.UserCompany.Logar(user, password);
            if (loguei != null)
            {
                TokenRemember = isRemember; //Colocar esse primeiro, pq os proximos usam esse valor
                _login = loguei.Email;
                Token = loguei.Token.ToString();
                _userCompany = loguei;
                return true;
            }
            else
                return false;
        }

        public void Logoff()
        {
            _userCompany = null;
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
