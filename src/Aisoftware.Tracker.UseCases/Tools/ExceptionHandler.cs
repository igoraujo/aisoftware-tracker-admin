using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tools
{
    public static class ExceptionHandler
    {

    }

    public class MoviyException : Exception
    {
        public MoviyException(string message) : base(message) { }
    }
}
