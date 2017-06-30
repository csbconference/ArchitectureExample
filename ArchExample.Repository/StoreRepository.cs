using System;
using System.Collections.Generic;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Repository;
using System.Linq;
using ArchExample.Common.Exceptions;

namespace ArchExample.Repository
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(ILogHelper logHelper) 
            : base(logHelper)
        { }

        public IList<Common.Entities.Store> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    totalRecordsFound = context.Stores.Count(c => !c.Deleted);

                    var stores = context.Stores.Where(c => !c.Deleted)
                        .OrderBy(c => c.CreatedAt)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize).ToList();


                    var result = new List<Common.Entities.Store>();
                    foreach (var store in stores)
                    {
                        result.Add(new Common.Entities.Store
                        {
                            Id = store.Id,
                            Name = store.Name,
                            Address = store.Address
                        });
                    }

                    return result;
                }
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new RepositoryException(e);
            }
        }

        public void Add(Common.Entities.Store store)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var newStore = context.Stores.Create();
                    newStore.CreatedAt = DateTimeOffset.UtcNow;
                    newStore.Name = store.Name;
                    newStore.Address = store.Address;
                    context.Stores.Add(newStore);

                    context.SaveChanges();

                    store.Id = newStore.Id;
                }
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new RepositoryException(e);
            }
        }

        public Common.Entities.Store GetById(int id)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var store = context.Stores.FirstOrDefault(s => s.Id == id && !s.Deleted);
                    if (store == null)
                    {
                        throw new RecordNotFoundException(string.Format("Store not found by id: {0}", id));
                    }

                    return new Common.Entities.Store
                    {
                        Id = store.Id,
                        Name = store.Name,
                        Address = store.Address
                    };
                }
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new RepositoryException(e);
            }
        }

        public void Update(Common.Entities.Store store)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var storeEF = context.Stores.FirstOrDefault(s => s.Id == store.Id && !s.Deleted);
                    if (storeEF == null)
                    {
                        throw new RecordNotFoundException(string.Format("Store not found by id: {0}", store.Id));
                    }
                    
                    storeEF.Name = store.Name;
                    storeEF.Address = store.Address;

                    context.SaveChanges();
                }
            }
            catch (ArchExampleException)
            {
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw new RepositoryException(e);
            }
        }
    }
}
