using Common.Modules;
using System;
using System.Collections.Generic;

namespace GenerationFactory
{
    public class GenerationManager
    {
        public static List<DepartmentModel> GetAllDepartments()
        {
            return new List<DepartmentModel>();
        }

        public static List<PositionModel> GetAllPostions()
        {
            return new List<PositionModel>();
        }

        public static List<EmployeeModel> GetAllManager(Guid? positionId = null)
        {
            return new List<EmployeeModel>();
        }
    }
}
