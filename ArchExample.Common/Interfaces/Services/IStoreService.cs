﻿using System.Collections.Generic;
using ArchExample.Common.Entities;

namespace ArchExample.Common.Interfaces.Services
{
    public interface IStoreService
    {
        IList<Store> Get(int page, int pageSize, out int totalRecordsFound);

        void Add(Store store);

        Store GetById(int id);

        void Update(Store store);

        decimal CalculatePayment(int storeId, int hoursWorked);
    }
}
