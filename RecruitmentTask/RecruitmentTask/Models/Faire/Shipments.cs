using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Faire
{
    public class Shipments
    {
        public int Id { get; set; }
        public string Order_id { get; set; }
        public decimal Maker_cost_cents { get; set; }
        public string Carrier { get; set; }
        public string Tracking_code { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
