using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aisoftware.Tracker.Borders;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class BalanceHandler : BaseHandler<Balance>
    {
        public BalanceHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.balance) { }

        public Balance Get(Guid id)
        {
            try
            {
                return new Balance();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
