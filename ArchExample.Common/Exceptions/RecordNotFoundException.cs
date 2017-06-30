using System;

namespace ArchExample.Common.Exceptions
{
    public class RecordNotFoundException : ArchExampleException
    {
        public RecordNotFoundException()
            : base()
        { }

        public RecordNotFoundException(string message)
            : base(message)
        { }

        public RecordNotFoundException(Exception innerException)
            : base(innerException.Message, innerException)
        { }

        public RecordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
