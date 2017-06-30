using System;

namespace ArchExample.Common.Exceptions
{
    public class DomainException : ArchExampleException
    {
        public DomainException()
            : base()
        { }

        public DomainException(string message)
            : base(message)
        { }

        public DomainException(Exception innerException)
            : base(innerException.Message, innerException)
        { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
