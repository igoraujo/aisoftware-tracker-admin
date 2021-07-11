using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Aisoftware.Tracker.Admin.Code;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class PrivacyModel : MoviyPageModel
    {
        public PrivacyModel(HandlerFactory handlerFactory) : base(handlerFactory) { }

        protected override bool AreaLogada() => false;

        public void OnGet()
        {
        }
    }
}
