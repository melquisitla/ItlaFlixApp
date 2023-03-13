using System;

namespace ItlaFlixApp.BL.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) 
        { 
        //Agregar logica de mensajes para manejo de excepciones de los usuarios
        }
    }
}
