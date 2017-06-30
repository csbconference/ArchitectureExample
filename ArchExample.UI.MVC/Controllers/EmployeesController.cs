using System.Collections.Generic;
using System.Web.Mvc;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Services;
using ArchExample.UI.MVC.Models;

namespace ArchExample.UI.MVC.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IStoreService _storeService;

        public EmployeesController(ILogHelper logHelper, IEmployeeService employeeService, IStoreService storeService)
            : base(logHelper)
        {            
            _employeeService = employeeService;
            _storeService = storeService;
        }

        // GET: Employees
        public ActionResult Index(int storeId)
        {
            try
            {
                var store = _storeService.GetById(storeId);
                ViewBag.StoreName = store.Name;
                int totalRecords;
                var employees = _employeeService.GetByStoreId(storeId, 1, int.MaxValue, out totalRecords);

                var storesModel = new List<EmployeeModel>();
                foreach (var employee in employees)
                {
                    storesModel.Add(new EmployeeModel
                    {
                        CI = employee.CI,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        HourlyPayment = employee.HourlyPayment
                    });
                }
                return View(storesModel);
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
                return RedirectToAction("Error");
            }
        }
        
        public ActionResult CalculatePayment(string employeeCI, int? hoursWorked)
        {
            try
            {
                var employee = _employeeService.GetByCI(employeeCI);
                decimal totalPayment = 0;
                int hoursWorkedValue = 0;
                if (hoursWorked.HasValue)
                {
                    totalPayment = _employeeService.CalculatePayment(employeeCI, hoursWorked.Value);
                    hoursWorkedValue = hoursWorked.Value;
                }

                return View(new EmployeeModel
                {
                    CI = employee.CI,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    HoursWorked = hoursWorkedValue,
                    HourlyPayment = employee.HourlyPayment,
                    TotalPayment = totalPayment
                });
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
                return RedirectToAction("Error");
            }
        }
    }
}