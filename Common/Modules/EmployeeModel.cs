using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modules
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public Guid? AspNetUsersId { get; set; }
        public string FullName { get; set; }
        public string DayOfBirth { get; set; }
        public string Gender { get; set; }
        public string JoinedDate { get; set; }
        public string LeftDate { get; set; }
        public string Skyped { get; set; }
        public Guid? CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
