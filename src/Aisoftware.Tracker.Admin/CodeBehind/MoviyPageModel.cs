using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aisoftware.Tracker.Admin.Views;
using Aisoftware.Tracker.UseCases.Handlers;
using System;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.Admin.CodeBehind
{
    public abstract class AisoftwareTrackerPageModel : PageModel
    {
        public readonly HandlerFactory HandlerFactory;
        private bool _paginaDeError;

        public AisoftwareTrackerPageModel(HandlerFactory handlerFactory, bool paginaDeError = false) : base()
        {
            HandlerFactory = handlerFactory;
            _paginaDeError = paginaDeError;
        }

        protected abstract bool LoggedArea();

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            base.OnPageHandlerSelected(context);

            if (HandlerFactory != null)
                HandlerFactory.UserIP = UserIP;

            if (LoggedArea() && !MoviyCode.Auth.IsLogged())
            {
                var path = Request.Path.ToString();
                if (path.StartsWith(@"\") || path.StartsWith(@"/"))
                    path = path.Substring(1);

                throw new UsuarioNaoLogadoException(System.Web.HttpUtility.UrlEncode(path + Request.QueryString));
            }
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //base.OnPageHandlerExecuting(context);

            //if (!_paginaDeError)
            //{
            //    if (!MyCode.PermitirIP())
            //        throw new IpNegadoException();

            //    if (PrecisaLogar() && (MyCode.Identidade.UsuarioLogado == null || MyCode.Identidade.UsuarioLogado.StatusCadastro == RA.Core.Models.Usuario.enumStatusCadastro.NEGADA.ToString()))
            //        throw new UsuarioNegadoException();
            //}
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
        }

        private AisoftwareTrackerCodeBehind _MoviyCode;
        public AisoftwareTrackerCodeBehind MoviyCode
        {
            get
            {
                if (_MoviyCode == null)
                {
                    _MoviyCode = new AisoftwareTrackerCodeBehind(this.Request, this.Response, HandlerFactory);
                }
                return _MoviyCode;
            }
        }

        public string UserIP
        {
            get { return Request.HttpContext.Connection.RemoteIpAddress.ToString(); }
        }
    }

    public class CustomPageFilter : IAsyncPageFilter
    {
        //TODO: Deixei isso pa ver se temos um uso, mas não estamos usando por enquanto
        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            await next.Invoke();
        }
    }
}