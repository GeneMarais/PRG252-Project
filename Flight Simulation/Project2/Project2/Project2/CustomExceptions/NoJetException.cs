using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Project2
{
    class NoJetException : Exception
    {
        public NoJetException()
        {
        }

        public NoJetException(string message) : base(message)
        {
        }

        public NoJetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
