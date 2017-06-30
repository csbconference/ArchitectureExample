using System.Collections.Generic;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Repository;
using System;
using System.Linq;
using ArchExample.Common.Exceptions;

namespace ArchExample.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(ILogHelper logHelper) 
            : base(logHelper)
        { }

        public IList<Common.Entities.Employee> Get(int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    totalRecordsFound = context.Employees.Count(c => !c.Deleted);

                    var employees = context.Employees.Where(c => !c.Deleted)
                        .OrderBy(c => c.CreatedAt)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize).ToList();


                    var result = new List<Common.Entities.Employee>();
                    foreach (var employee in employees)
                    {
                        result.Add(new Common.Entities.Employee
                        {
                            CI = employee.CI,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            HourlyPayment = employee.HourlyPayment
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

        public IList<Common.Entities.Employee> GetByStoreId(int storeId, int page, int pageSize, out int totalRecordsFound)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var query = from e in context.Employees
                        join es in context.EmployeeStores
                            on e.CI equals es.EmployeeCI
                        where es.StoreId == storeId && !e.Deleted && !es.Deleted
                        select e;

                    totalRecordsFound = query.Count();

                    var employees = query.OrderBy(c => c.CreatedAt)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize).ToList();

                    var result = new List<Common.Entities.Employee>();
                    foreach (var employee in employees)
                    {
                        result.Add(new Common.Entities.Employee
                        {
                            CI = employee.CI,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            HourlyPayment = employee.HourlyPayment
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

        public void Add(Common.Entities.Employee employee)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var newEmployee = context.Employees.Create();
                    newEmployee.CreatedAt = DateTimeOffset.UtcNow;
                    newEmployee.CI = employee.CI;
                    newEmployee.FirstName = employee.FirstName;
                    newEmployee.LastName = employee.LastName;
                    newEmployee.HourlyPayment = employee.HourlyPayment;
                    context.Employees.Add(newEmployee);

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

        public Common.Entities.Employee GetByCI(string ci)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var employee = context.Employees.FirstOrDefault(e => e.CI == ci && !e.Deleted);
                    if (employee == null)
                    {
                        throw new RecordNotFoundException(string.Format("Employee not found by ci: {0}", ci));
                    }

                    return new Common.Entities.Employee
                    {
                        CI = employee.CI,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        HourlyPayment = employee.HourlyPayment
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

        public void Update(Common.Entities.Employee employee)
        {
            try
            {
                using (var context = new ArchExampleEntities())
                {
                    var employeeEF = context.Employees.FirstOrDefault(e => e.CI == employee.CI && !e.Deleted);
                    if (employeeEF == null)
                    {
                        throw new RecordNotFoundException(string.Format("Employee not found by ci: {0}", employee.CI));
                    }

                    employeeEF.CI = employee.CI;
                    employeeEF.FirstName = employee.FirstName;
                    employeeEF.LastName = employee.LastName;
                    employeeEF.HourlyPayment = employee.HourlyPayment;

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
