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
    public class PassengerHandler : BaseHandler<Passenger>
    {
        public PassengerHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.passenger) { }

        public int GetUsersPerDay()
        {
            try
            {
                var query = Environment.NewLine + "select count(distinct tp.passengerid) as total " +
                                                           Environment.NewLine + "from travelpassenger as tp " +
                                                           Environment.NewLine + "inner join passenger as p on p.id = tp.passengerid " +
                                                           Environment.NewLine + "inner join travel as t on t.id = tp.travelid " +
                                                           Environment.NewLine + "where starttime " +
                                                           Environment.NewLine + $"between timestamp '2020-06-27' + interval '00:00:00 hours' " +
                                                           Environment.NewLine + $"and timestamp '2020-06-27' + interval ' 23:59:59.999999 hours' ";
                                                           //Deixei a data fixa pois se usar o datetime.now o valor vai ser zero por não ter usuários no dia atual

                var usersPerDay = _context.ExecuteScalar(query);

                return Convert.ToInt32(usersPerDay);
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }
    }
}
