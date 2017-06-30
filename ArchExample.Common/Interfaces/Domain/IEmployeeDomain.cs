using System.Collections.Generic;
using ArchExample.Common.Entities;

namespace ArchExample.Common.Interfaces.Domain
{
    public interface IEmployeeDomain
    {
        IList<Employee> Get(int page, int pageSize, out int totalRecordsFound);

        IList<Employee> GetByStoreId(int storeId, int page, int pageSize, out int totalRecordsFound);

        void Add(Employee employee);

        Employee GetByCI(string ci);

        void Update(Employee employee);

        decimal CalculatePayment(string ci, int hoursWorked);
    }
}
