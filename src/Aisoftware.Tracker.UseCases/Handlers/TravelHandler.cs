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
using Aisoftware.Tracker.Models.ViewModels;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class TravelHandler : BaseHandler<Travel>
    {
        public TravelHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.travel) { }

        public int GetActiveTravelsPerDay()
        {
            try
            {
                var query = Environment.NewLine + "select count(id) as total " +
                                                           Environment.NewLine + "from travel " +
                                                           Environment.NewLine + "where starttime " +
                                                           Environment.NewLine + $"between timestamp '2020-06-27' + interval '00:00:00 hours' " +
                                                           Environment.NewLine + $"and timestamp '2020-06-27' + interval ' 23:59:59.999999 hours' ";
                                                           //Deixei a data fixa pois se usar o datetime.now o valor vai ser zero por não ter viagens ativas no dia atual

                var activeTravelsPerDay = _context.ExecuteScalar(query);

                return Convert.ToInt32(activeTravelsPerDay);
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }

        public int GetActiveTravels()
        {
            try
            {
                var query = Environment.NewLine + "select count(id) as total " +
                                                           Environment.NewLine + "from travel " +
                                                           Environment.NewLine + "where starttime " +
                                                           Environment.NewLine + $"between timestamp '2020-06-27' + interval '00:00:00 hours' " +
                                                           Environment.NewLine + $"and timestamp '2020-06-27' + interval ' 23:59:59.999999 hours' " +
                                                           Environment.NewLine + "and finishtime is null";
                                                           //Deixei a data fixa pois se usar o datetime.now o valor vai ser zero por não ter viagens ativas no dia atual

                var activeTravels = _context.ExecuteScalar(query);

                return Convert.ToInt32(activeTravels);
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }

        public List<ActiveTravelsPerDay> GetActiveTravelsPerDayList()
        {
            var query = Environment.NewLine + "select " +
                        Environment.NewLine + "t.id, " +
                        Environment.NewLine + "t.driverid, " +
                        Environment.NewLine + "t.carid, " +
                        Environment.NewLine + "t.lineid, " +
                        Environment.NewLine + "d.name as driver, " +
                        Environment.NewLine + "c.licenseplate, " +
                        Environment.NewLine + "l.number as line, " +
                        Environment.NewLine + "l.description, " +
                        Environment.NewLine + "tk.price, " +
                        Environment.NewLine + "c.typeid, " +
                        Environment.NewLine + "t.starttime, " +
                        Environment.NewLine + "t.finishtime " +
                        Environment.NewLine + "from travel as t " +
                        Environment.NewLine + "inner join car as c on c.id = t.carid " +
                        Environment.NewLine + "inner join driver as d on d.id = t.driverid " +
                        Environment.NewLine + "inner join line as l on l.id = t.lineid " +
                        Environment.NewLine + "inner join ticket as tk on tk.id = l.ticketid " +
                        Environment.NewLine + "where starttime " +
                        Environment.NewLine + "between timestamp '2020-06-27' + interval '00:00:00 hours' " +
                        Environment.NewLine + "and timestamp '2020-06-27' + interval ' 23:59:59.999999 hours'";

            List<ActiveTravelsPerDay> activeTravelsPerDayList = _context.ActiveTravelsPerDay.FromSqlRaw(query).ToList();

            return activeTravelsPerDayList;
        }
    }
}
