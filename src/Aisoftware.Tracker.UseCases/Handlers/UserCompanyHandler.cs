using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aisoftware.Tracker.Borders;
using System.Web;
using Aisoftware.Tracker.UseCases.Tools;
using Server.Tools;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class UserCompanyHandler : BaseHandler<User>
    {
        public UserCompanyHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.user) { }

        public bool Atualizar(User user)
        {
            try
            {
                _context.user.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Get(string id)
        {
            try
            {
                return _context.user.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetByToken(string token)
        {
            try
            {
                return _context.user.AsNoTracking().Where(x => x.Token == token).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Logar(string email, string senha)
        {
            try
            {
                email = HttpUtility.UrlDecode(email).ToLower().Trim();
                senha = HttpUtility.UrlDecode(senha);

                var userCompany = _context.user.Where(u => u.Email == email.Trim().ToLower() && u.Password == EncryptionHandler.Encrypt(senha)).FirstOrDefault(); /*_context.UserCompany.AsNoTracking().Where(u => u.Email == email && u.Password == EncryptionHandler.Encrypt(senha)).FirstOrDefault();*/

                if (userCompany != null) { return userCompany; }
                else
                {
                    throw new MoviyException(Constantes.msgUsuarioSenhaErrado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
