using Aisoftware.Tracker.Models;
using Aisoftware.Tracker.UseCases.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.Admin.Code
{
    public class Identidade
    {
        private MoviyCode _moviyCode;
        private HandlerFactory _handlerFactory;

        public Identidade(MoviyCode moviyCode, HandlerFactory handlerFactory)
        {
            _moviyCode = moviyCode;
            _handlerFactory = handlerFactory;
        }

        public string Login = string.Empty;

        public bool EstaLogado()
        {
            return !string.IsNullOrEmpty(tokenmoviy);
        }

        private UserCompany _userCompany = null;

        public UserCompany UsuarioLogado
        {
            get
            {
                if (_userCompany == null && tokenmoviy != Guid.Empty.ToString())
                {
                    _userCompany = _handlerFactory.UserCompany.GetByToken(tokenmoviy);
                }
                return _userCompany;
            }
        }

        public async Task<bool> LogarUsuario(string ip, string usuario, string senha, bool lembrardemim)
        {
            var loguei = _handlerFactory.UserCompany.Logar(usuario, senha);
            if (loguei != null)
            {
                tokenremember = lembrardemim; //Colocar esse primeiro, pq os proximos usam esse valor
                Login = loguei.Email;
                tokenmoviy = loguei.Token.ToString();
                _userCompany = loguei;
                return true;
            }
            else
                return false;
        }

        public void DeslogarUsuario()
        {
            _userCompany = null;
            tokenremember = false;
            tokenmoviy = null;
            Login = string.Empty;
        }

        public bool tokenremember
        {
            get
            {
                return _moviyCode.GetValue("tokenremember") == "S";
            }
            set
            {
                _moviyCode.SaveValue("tokenremember", value, null);
            }
        }
        public string tokenmoviy
        {
            get
            {
                return _moviyCode.GetValue("tokenmoviy");
            }
            set
            {
                _moviyCode.SaveValue("tokenmoviy", value, null);
            }
        }
    }
}
