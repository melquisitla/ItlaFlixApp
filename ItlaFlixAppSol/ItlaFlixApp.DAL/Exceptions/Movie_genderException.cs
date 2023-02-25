using System;

namespace ItlaFlixApp.DAL.Exceptions
{
    internal class Movie_genderException : Exception
    {
        public Movie_genderException(string message) :base(message) {
        
        }
    }
}
