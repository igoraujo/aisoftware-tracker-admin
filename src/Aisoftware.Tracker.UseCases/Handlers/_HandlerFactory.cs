using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class HandlerFactory : IDisposable
    {
        public static IHostingEnvironment Environment;

        private IOptions<Config> _config;

        private ApplicationDbContext _context;
        public ApplicationDbContext DBContext
        {
            get
            {
                return _context;
            }
        }

        private string _userIP;
        public string UserIP
        {
            get
            {
                return _userIP;
            }
            set
            {
                if (_config != null)
                    _config.Value.UserIP = value;

                _userIP = value;
            }
        }

        public HandlerFactory(ApplicationDbContext dbContext, IOptions<Config> config)
        {
            _context = dbContext;
            _config = config;
        }

        public void Detached(object entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        private BalanceHandler _balance;
        public BalanceHandler Balance => _balance ?? (_balance = new BalanceHandler(_context, _config, this));

        private DriverHandler _driver;
        public DriverHandler Driver => _driver ?? (_driver = new DriverHandler(_context, _config, this));

        private PassengerHandler _passenger;
        public PassengerHandler Passenger => _passenger ?? (_passenger = new PassengerHandler(_context, _config, this));

        private TicketHandler _ticket;
        public TicketHandler Ticket => _ticket ?? (_ticket = new TicketHandler(_context, _config, this));

        private TravelHandler _travel;
        public TravelHandler Travel => _travel ?? (_travel = new TravelHandler(_context, _config, this));

        private UserCompanyHandler _userCompany;
        public UserCompanyHandler User => _userCompany ?? (_userCompany = new UserCompanyHandler(_context, _config, this));

        public void Dispose()
        {

        }
    }
}
