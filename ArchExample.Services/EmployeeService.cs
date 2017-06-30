using System;
using System.Collections.Generic;
using ArchExample.Common.Entities;
using ArchExample.Common.Exceptions;
using ArchExample.Common.Interfaces.Domain;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Services;

namespace ArchExample.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeDomain _employeeDomain;
        private readonly IMailHelper _mailHelper;

        public EmployeeService(ILogHelper logHelper, IEmployeeDomain employeeDomain, IMailHelper mailHelper)
            : base(logHelper)
        {
            _employeeDomain = employeeDomain;
            _mailHelper = mailHelper;
        }

        public IList<Employee> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _employeeDomain.Get(page, pageSize, out totalRecordsFound);
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

        public IList<Employee> GetByStoreId(int storeId, int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                return _employeeDomain.GetByStoreId(storeId, page, pageSize, out totalRecordsFound);
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

        public void Add(Employee employee)
        {
            try
            {
                _employeeDomain.Add(employee);
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

        public Employee GetByCI(string ci)
        {
            try
            {
                return _employeeDomain.GetByCI(ci);
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

        public void Update(Employee employee)
        {
            try
            {
                _employeeDomain.Update(employee);
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

        public decimal CalculatePayment(string ci, int hoursWorked)
        {
            try
            {
                var payment = _employeeDomain.CalculatePayment(ci, hoursWorked);
                _mailHelper.SendMail("myemail@testmail.com", string.Format("Payment calculated for employee: {0}", ci), string.Format("Total payment calculated: {0}", payment));
                return payment;
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