using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Reward
    {
        public int RewardId { get; set; }
        public int CampaignId { get; set; }
        public int CustomerId { get; set; }
        public decimal RewardAmount { get; set; }
        public DateTime RewardDate { get; set; }
        public bool? Valid { get; set; }

        public virtual Campaign Campaign { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
