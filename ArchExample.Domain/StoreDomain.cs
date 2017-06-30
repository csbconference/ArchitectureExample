using System.Collections.Generic;
using ArchExample.Common.Entities;
using ArchExample.Common.Interfaces.Domain;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Repository;
using ArchExample.Common.Exceptions;
using System;

namespace ArchExample.Domain
{
    public class StoreDomain : BaseDomain, IStoreDomain
    {
        private readonly IStoreRepository _storeRepository;

        public StoreDomain(ILogHelper logHelper, IStoreRepository storeRepository) 
            : base(logHelper)
        {
            _storeRepository = storeRepository;
        }

        public IList<Store> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _storeRepository.Get(page, pageSize, out totalRecordsFound);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new DomainException(e);
            }
        }

        public void Add(Store store)
        {
            try
            {
                _storeRepository.Add(store);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new DomainException(e);
            }
        }

        public Store GetById(int id)
        {
            try
            {
                return _storeRepository.GetById(id);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new DomainException(e);
            }
        }

        public void Update(Store store)
        {
            try
            {
                _storeRepository.Update(store);
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new DomainException(e);
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
                throw new DomainException(e);
            }
        }
    }
}
