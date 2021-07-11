using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aisoftware.Tracker.Models;
using Aisoftware.Tracker.Admin.Code;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class LoginModel : MoviyPageModel
    {
        public LoginModel(HandlerFactory handlerFactory) : base(handlerFactory) { }
        
        protected override bool AreaLogada() => false;

        [BindProperty]
        public UserCompany userCompany { get; set; }
        
        [BindProperty]
        public bool Lembrardemim { get; set; }

        public IActionResult OnGet(string returnTo)
        {
            if (returnTo?.ToLower() == "logout")
            {
                MoviyCode.Identidade.DeslogarUsuario();
                return Page();
            }
            else
            {
                try
                {
                    if (MoviyCode.Identidade.EstaLogado())
                        return Redirect("Dashboard");
                }
                catch (Exception ex) { }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostLogin(string returnTo)
        {
            try
            {
                if (await MoviyCode.Identidade.LogarUsuario(Request.HttpContext.Connection.RemoteIpAddress.ToString(), userCompany.Email, userCompany.Password, Lembrardemim))
                {
                    return Redirect("Dashboard");
                }
                else { MoviyCode.AdicionaErro(Constantes.msgUsuarioSenhaErrado); }

                return Page();
            }
            catch (Exception ex)
            {
                MoviyCode.AdicionaErro(ex.Message);
                return Page();
            }
        }
    }
}