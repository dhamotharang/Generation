using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFactory.DataProviders
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        // Relationship objects
        public ICollection<Employee> Employees { get; set; }
    }
}
