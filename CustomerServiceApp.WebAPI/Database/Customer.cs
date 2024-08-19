using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Customer
    {
        public Customer()
        {
            Purchases = new HashSet<Purchase>();
            Rewards = new HashSet<Reward>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Valid { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
