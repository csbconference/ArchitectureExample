using System;

namespace ArchExample.Common.Exceptions
{
    public class RepositoryException : ArchExampleException
    {
        public RepositoryException()
            : base()
        { }

        public RepositoryException(string message)
            : base(message)
        { }

        public RepositoryException(Exception innerException)
            : base(innerException.Message, innerException)
        { }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
