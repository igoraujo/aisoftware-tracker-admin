using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.Admin.CodeBehind;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class IndexModel : AisoftwareTrackerPageModel
    {
        public IndexModel(HandlerFactory handlerFactory) : base(handlerFactory) { }
        
        protected override bool LoggedArea() => false;

        [BindProperty]
        public User user { get; set; }
        
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
                if (await MoviyCode.Auth.Login(Request.HttpContext.Connection.RemoteIpAddress.ToString(), user.Email, user.Password, IsRemember))
                {
                    if (string.IsNullOrEmpty(returnTo))
                    {
                        return Redirect("Dashboard");
                    }
                    else return Redirect(returnTo);
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