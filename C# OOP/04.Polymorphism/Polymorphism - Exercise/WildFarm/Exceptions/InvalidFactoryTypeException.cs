using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid type!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }
    }
}
