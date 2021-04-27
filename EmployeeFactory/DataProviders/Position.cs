using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFactory.DataProviders
{
    public class Position
    {
        public Guid Id { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
    }
}
