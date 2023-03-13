using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.DAL.Exceptions
{
    public class RentException : Exception
    {
        public RentException(string message) : base(message) { }
    }
}
