using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.Admin.CodeBehind;
using Aisoftware.Tracker.UseCases.Handlers;
using Aisoftware.Tracker.Borders.Users.Entities;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class LoginModel : AisoftwareTrackerPageModel
    {
        public LoginModel(HandlerFactory handlerFactory) : base(handlerFactory) { }
        
        protected override bool LoggedArea() => false;

        [BindProperty]
        public User userCompany { get; set; }
        
        [BindProperty]
        public bool IsRemember { get; set; }

        public IActionResult OnGet(string returnTo)
        {
            if (returnTo?.ToLower() == "logout")
            {
                MoviyCode.Auth.Logoff();
                return Page();
            }
            else
            {
                try
                {
                    if (MoviyCode.Auth.IsLogged())
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
                if (await MoviyCode.Auth.Login(Request.HttpContext.Connection.RemoteIpAddress.ToString(), userCompany.Email, userCompany.Password, IsRemember))
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