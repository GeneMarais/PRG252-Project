using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Project2
{
    class NoRouteException : Exception
    {
        public NoRouteException()
        {
        }

        public NoRouteException(string message) : base(message)
        {
        }

        public NoRouteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
