using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Exceptions
{
    public class MovieGenderException : Exception
    {
        public MovieGenderException(string message) : base(message)
        {
            //  Agregar Logica 
        }
    }
}
