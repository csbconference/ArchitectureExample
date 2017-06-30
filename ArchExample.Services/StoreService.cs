using System;
using System.Collections.Generic;
using ArchExample.Common.Entities;
using ArchExample.Common.Exceptions;
using ArchExample.Common.Interfaces.Domain;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Services;

namespace ArchExample.Services
{
    public class StoreService : BaseService, IStoreService
    {
        private readonly IStoreDomain _storeDomain;

        public StoreService(ILogHelper logHelper, IStoreDomain storeDomain)
            : base(logHelper)
        {
            _storeDomain = storeDomain;
        }

        public IList<Store> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _storeDomain.Get(page, pageSize, out totalRecordsFound);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new ServiceException(e);
            }
        }

        public void Add(Store store)
        {
            try
            {
                _storeDomain.Add(store);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new ServiceException(e);
            }
        }

        public Store GetById(int id)
        {
            try
            {
                return _storeDomain.GetById(id);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new ServiceException(e);
            }
        }

        public void Update(Store store)
        {
            try
            {
                _storeDomain.Update(store);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new ServiceException(e);
            }
        }

        public decimal CalculatePayment(int storeId, int hoursWorked)
        {
            try
            {
                return 0;
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new ServiceException(e);
            }
        }
    }
}