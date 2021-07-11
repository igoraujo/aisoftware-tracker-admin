using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.UseCases
{
    public class Config : IOptions<Config>
    {
        public string UserIP { get; set; }

        public Config Value { get { return this; } }
    }
}
