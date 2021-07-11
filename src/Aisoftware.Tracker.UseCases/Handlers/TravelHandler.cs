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
                return 1;
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
                return 1;
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }

        public List<ActiveTravelsPerDay> GetActiveTravelsPerDayList()
        {
            return new List<ActiveTravelsPerDay>();
        }
    }
}
