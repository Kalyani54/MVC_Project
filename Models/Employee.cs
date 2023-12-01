using System;
using System.Collections.Generic;

namespace MVC_TravelProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TravelRequests = new HashSet<TravelRequest>();
        }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Contact { get; set; }
        public string? Dept { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<TravelRequest> TravelRequests { get; set; }
    }
}
