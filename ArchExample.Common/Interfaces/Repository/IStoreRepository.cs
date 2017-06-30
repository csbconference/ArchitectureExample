using System.Collections.Generic;
using ArchExample.Common.Entities;

namespace ArchExample.Common.Interfaces.Repository
{
    public interface IStoreRepository
    {
        IList<Store> Get(int page, int pageSize, out int totalRecordsFound);

        void Add(Store store);

        Store GetById(int id);

        void Update(Store store);
    }
}