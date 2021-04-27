﻿using System;

namespace EmployeeFactory.DataProviders
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid? AspNetUsersId { get; set; }
        public string FullName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public string Skyped { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Add new columns
        public Guid? DepartmentId { get; set; }
        public Guid? PositionId { get; set; }
        public Guid? ManagerId { get; set; }

        // Relationship objects
        public Department Department { get; set; }
        public Position Position { get; set; }
    }
}
