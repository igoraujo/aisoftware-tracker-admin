using Microsoft.EntityFrameworkCore;
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
    public class TicketHandler : BaseHandler<Ticket>
    {
        public TicketHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.ticket) { }

        public int GetSoldTicketsPerDay()
        {
            try
            {
                return 1;
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }
    }
}
