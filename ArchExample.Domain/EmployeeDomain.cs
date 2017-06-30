using System.Collections.Generic;
using ArchExample.Common.Entities;
using ArchExample.Common.Interfaces.Domain;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Repository;
using ArchExample.Common.Exceptions;
using System;

namespace ArchExample.Domain
{
    public class EmployeeDomain : BaseDomain, IEmployeeDomain
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDomain(ILogHelper logHelper, IEmployeeRepository employeeRepository)
            : base(logHelper)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _employeeRepository.Get(page, pageSize, out totalRecordsFound);
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

        public IList<Employee> GetByStoreId(int storeId, int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _employeeRepository.GetByStoreId(storeId, page, pageSize, out totalRecordsFound);
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

        public void Add(Employee employee)
        {
            try
            {
                _employeeRepository.Add(employee);
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

        public Employee GetByCI(string ci)
        {
            try
            {
                return _employeeRepository.GetByCI(ci);
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

        public void Update(Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);
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

        public decimal CalculatePayment(string ci, int hoursWorked)
        {
            try
            {
                var employee = _employeeRepository.GetByCI(ci);
                decimal totalPayment = employee.HourlyPayment * hoursWorked;
                decimal increment = totalPayment * 0.07m;
                decimal netPayment = totalPayment + increment;
                return netPayment;
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
