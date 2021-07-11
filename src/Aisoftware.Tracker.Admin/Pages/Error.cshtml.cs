using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aisoftware.Tracker.Admin.Code;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : MoviyPageModel
    {
        public ErrorModel(HandlerFactory handlerFactory) : base(handlerFactory, true)
        { }

        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public IActionResult OnGet()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var erro = exceptionHandlerPathFeature.Error;

            if (erro.GetType() == typeof(Aisoftware.Tracker.Admin.Pages.UsuarioNaoLogadoException))
                return Redirect("/Login/" + erro.Message);

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            return Page();
        }
        protected override bool AreaLogada() => false;
    }


    [Serializable]
    public class UsuarioNaoLogadoException : Exception
    {
        public UsuarioNaoLogadoException() { }
        public UsuarioNaoLogadoException(string message) : base(message) { }
        public UsuarioNaoLogadoException(string message, Exception inner) : base(message, inner) { }
        protected UsuarioNaoLogadoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
