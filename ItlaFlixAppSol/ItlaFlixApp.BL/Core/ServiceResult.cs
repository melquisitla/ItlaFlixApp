using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ItlaFlixApp.BL.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
    }
}
