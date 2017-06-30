using ArchExample.Common.Interfaces.Helpers;

namespace ArchExample.Domain
{
    public abstract class BaseDomain
    {
        private readonly ILogHelper _logHelper;

        protected ILogHelper Logger
        {
            get
            {
                return _logHelper;
            }
        }

        public BaseDomain(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }
    }
}
