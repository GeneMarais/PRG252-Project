using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Project2
{
    class FuelException : Exception
    {
        public FuelException()
        {
        }

        public FuelException(string message) : base(message)
        {
        }

        public FuelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
