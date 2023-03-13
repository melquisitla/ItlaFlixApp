using System;

namespace ItlaFlixApp.BL.Exceptions
{
    internal class SaleException : Exception
    {
        public SaleException(string message) : base(message)
        {
            //Agregar logica de mensajes para manejo de excepciones de las ventas
        }
    }
}
