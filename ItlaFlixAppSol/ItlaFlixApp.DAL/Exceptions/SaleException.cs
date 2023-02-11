using System;

namespace ItlaFlixApp.DAL.Exceptions
{
    public class SaleException : Exception
    {
        public SaleException(string message) :base(message)
        { 
            //crear logica para guardar la excepcion
            //luego de guardada la enviamos por correo
        }
    }
}
