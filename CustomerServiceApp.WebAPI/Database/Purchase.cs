using System;
using System.Collections.Generic;

namespace CustomerServiceApp.WebAPI.Database
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int? CampaignId { get; set; }
        public bool? Valid { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual Customer Customer { get; set; } = null!;
    }
}
