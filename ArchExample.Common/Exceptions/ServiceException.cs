using System;

namespace ArchExample.Common.Exceptions
{
    public class ServiceException : ArchExampleException
    {
        public ServiceException()
            : base()
        { }

        public ServiceException(string message)
            : base(message)
        { }

        public ServiceException(Exception innerException)
            : base(innerException.Message, innerException)
        { }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
