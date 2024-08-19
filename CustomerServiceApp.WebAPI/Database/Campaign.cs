using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Campaign
    {
        public Campaign()
        {
            Purchases = new HashSet<Purchase>();
            Rewards = new HashSet<Reward>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DailyLimit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Valid { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
