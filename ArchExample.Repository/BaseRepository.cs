using ArchExample.Common.Interfaces.Helpers;

namespace ArchExample.Repository
{
    public abstract class BaseRepository
    {
        private readonly ILogHelper _logHelper;

        protected ILogHelper Logger
        {
            get
            {
                return _logHelper;
            }
        }

        public BaseRepository(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }
    }
}
