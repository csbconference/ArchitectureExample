using ArchExample.Common.Interfaces.Repository;
using ArchExample.Tests;
using Autofac;
using NUnit.Framework;

namespace ArchExample.Repository.Tests
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        private IEmployeeRepository _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = ArchExampleTestContext.AutofacContainer.Resolve<IEmployeeRepository>();
        }

        [Test]
        public void TestGetEmployees()
        {
            int totalRecords;
            var employees = _employeeRepository.Get(1, 10, out totalRecords);
            Assert.IsNotNull(employees);
        }
    }
}
