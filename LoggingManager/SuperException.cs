using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingManager
{
    public class SuperException: ApplicationException
    {
        public SuperException(string message, Exception e)
            : base(message, e)
        {
            Except.Add(this);
        }

        public static List<SuperException> Except = new List<SuperException>();

       
    }
}