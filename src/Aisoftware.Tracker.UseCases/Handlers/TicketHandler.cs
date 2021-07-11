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
                var query = Environment.NewLine + "select count(tp.id) as totalticketssold " +
                                                           Environment.NewLine + "from travel as t " +
                                                           Environment.NewLine + "inner join travelpassenger as tp on tp.travelid = t.id " +
                                                           Environment.NewLine + "where starttime " +
                                                           Environment.NewLine + $"between timestamp '2020-06-27' + interval '00:00:00 hours' " +
                                                           Environment.NewLine + $"and timestamp '2020-06-27' + interval ' 23:59:59.999999 hours' ";
                                                           //Deixei a data fixa pois se usar o datetime.now o valor vai ser zero por não ter passagens vendidas no dia atual

                var soldTicketsPerDay = _context.ExecuteScalar(query);

                return Convert.ToInt32(soldTicketsPerDay);
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }
    }
}
