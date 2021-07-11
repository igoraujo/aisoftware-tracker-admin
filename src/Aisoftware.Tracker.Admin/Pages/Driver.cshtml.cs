using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.Admin.CodeBehind;
using Aisoftware.Tracker.UseCases.Handlers;
using X.PagedList;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class DriverModel : AisoftwareTrackerPageModel
    {
        public DriverModel(HandlerFactory handlerFactory) : base(handlerFactory) { }
        protected override bool LoggedArea() => true;

        public IPagedList<Driver> DriversList { get; set; }
        
        [BindProperty]
        public string Pesquisa { get; set; }

        [BindProperty]
        public string QtdRegistros { get; set; }

        [BindProperty]
        public string Pagina { get; set; }

        public void OnGet()
        {
            DriversList = HandlerFactory.Driver.GetAll(MoviyCode.Auth.UsuarioLogado.CompanyID, 1, 10);
        }

        public void OnPostPesquisar()
        {
            DriversList = HandlerFactory.Driver.GetAll(MoviyCode.Auth.UsuarioLogado.CompanyID, Convert.ToInt32(Pagina), Convert.ToInt32(QtdRegistros), Pesquisa);
        }
    }
}