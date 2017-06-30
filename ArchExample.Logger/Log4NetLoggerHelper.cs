using System;
using ArchExample.Common.Interfaces.Helpers;
using log4net;

namespace ArchExample.Logger
{
    public class Log4NetLoggerHelper : ILogHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetLoggerHelper));

        public void LogInfo(string message)
        {
            try
            {
                Logger.Info(message);
            }
            catch
            { }
        }

        public void LogError(string message)
        {
            try
            {
                Logger.Error(message);
            }
            catch
            { }
        }

        public void LogError(Exception exception)
        {
            try
            {
                Logger.Error(exception.Message, exception);
            }
            catch
            { }
        }

        public void LogError(string message, Exception exception)
        {
            try
            {
                Logger.Error(message, exception);
            }
            catch
            { }
        }
    }
}
