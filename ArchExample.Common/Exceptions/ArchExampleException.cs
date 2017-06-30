using System;

namespace ArchExample.Common.Exceptions
{
    public class ArchExampleException : Exception
    {
        public ArchExampleException()
            : base()
        { }

        public ArchExampleException(string message)
            : base(message)
        { }

        public ArchExampleException(Exception innerException)
            : base(innerException.Message, innerException)
        { }

        public ArchExampleException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
