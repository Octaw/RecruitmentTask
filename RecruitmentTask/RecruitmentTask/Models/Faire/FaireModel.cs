using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Faire
{
    public class FaireModel
    {
        public string Id { get; set; }
        public string Display_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string State { get; set; }
        public List<Items> Item { get; set; }
        public List<Shipments> Shipments { get; set; }
        public Address Address { get; set; }
        public string Retailer_id { get; set; }
        public DateTime Ship_after { get; set; }
        public Payout Payout_costs { get; set; }
        public string Source { get; set; }
        public DateTime Payment_initiated_atperty { get; set; }
        public string Original_order_id { get; set; }
    }
}
