﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aisoftware.Tracker.Models;
using System.Web;
using Aisoftware.Tracker.UseCases.Tools;
using Server.Tools;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class UserCompanyHandler : BaseHandler<UserCompany>
    {
        public UserCompanyHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.usercompany) { }

        public bool Atualizar(UserCompany userCompany)
        {
            try
            {
                _context.usercompany.Update(userCompany);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserCompany Get(string id)
        {
            try
            {
                return _context.usercompany.AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserCompany GetByToken(string token)
        {
            try
            {
                return _context.usercompany.AsNoTracking().Where(x => x.Token == token).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserCompany Logar(string email, string senha)
        {
            try
            {
                email = HttpUtility.UrlDecode(email).ToLower().Trim();
                senha = HttpUtility.UrlDecode(senha);

                var userCompany = _context.usercompany.Where(u => u.Email == email.Trim().ToLower() && u.Password == EncryptionHandler.Encrypt(senha)).FirstOrDefault(); /*_context.UserCompany.AsNoTracking().Where(u => u.Email == email && u.Password == EncryptionHandler.Encrypt(senha)).FirstOrDefault();*/

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