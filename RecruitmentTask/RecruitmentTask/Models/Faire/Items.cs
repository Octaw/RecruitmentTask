using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Faire
{
    public class Items
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string Order_id { get; set; }
        public string Product_id { get; set; }
        public string Product_option_id { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public decimal Price_cents { get; set; }
        public string Product_name { get; set; }
        public string Product_option_name { get; set; }
        public bool Includes_tester { get; set; }
    }
}
