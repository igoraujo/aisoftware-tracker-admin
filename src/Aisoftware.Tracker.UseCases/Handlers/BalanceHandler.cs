using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aisoftware.Tracker.Models;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class BalanceHandler : BaseHandler<Balance>
    {
        public BalanceHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.balance) { }

        public Balance Get(Guid id)
        {
            try
            {
                return _context.balance.AsNoTracking().Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
