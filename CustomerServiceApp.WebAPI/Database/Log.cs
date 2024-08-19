using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Log
    {
        public int LogId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public bool? Valid { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
