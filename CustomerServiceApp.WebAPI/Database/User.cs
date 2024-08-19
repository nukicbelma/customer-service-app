using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Valid { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Log> Logs { get; set; }
    }
}
