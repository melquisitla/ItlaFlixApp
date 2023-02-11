using System;

namespace ItlaFlixApp.DAL.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        { 
        
        }
    }
}
