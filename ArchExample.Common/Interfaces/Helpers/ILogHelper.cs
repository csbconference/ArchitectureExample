using System;

namespace ArchExample.Common.Interfaces.Helpers
{
    public interface ILogHelper
    {
        void LogInfo(string message);

        void LogError(string message);

        void LogError(Exception exception);

        void LogError(string message, Exception exception);
    }
}
