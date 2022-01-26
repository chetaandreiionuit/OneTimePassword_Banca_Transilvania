using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTP_Banca_Transilvania.Exceptions
{
    public class EntitySaveToDatabaseException : Exception
    {
        public EntitySaveToDatabaseException(string message) : base(message) { }
    }
}