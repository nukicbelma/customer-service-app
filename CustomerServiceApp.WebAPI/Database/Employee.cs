using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
