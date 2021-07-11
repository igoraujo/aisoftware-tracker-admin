using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Aisoftware.Tracker.Admin.CodeBehind;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Views
{
    public class PrivacyModel : AisoftwareTrackerPageModel
    {
        public PrivacyModel(HandlerFactory handlerFactory) : base(handlerFactory) { }

        protected override bool LoggedArea() => false;

        public void OnGet()
        {
        }
    }
}
