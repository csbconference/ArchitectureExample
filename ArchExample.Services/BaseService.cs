using ArchExample.Common.Interfaces.Helpers;

namespace ArchExample.Services
{
    public abstract class BaseService
    {
        private readonly ILogHelper _logHelper;

        protected ILogHelper Logger
        {
            get
            {
                return _logHelper;
            }
        }

        public BaseService(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }
    }
}
