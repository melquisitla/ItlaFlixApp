using System;
namespace ItlaFlixApp.BL.Exceptions
{
    public class MovieException : Exception
    {
        public MovieException(string message) : base(message) 
        {
          //para agregar logica
        }
    }
}
