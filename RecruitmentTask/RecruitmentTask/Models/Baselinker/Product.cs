using RecruitmentTask.Models.Faire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Baselinker
{
    public class Product
    {
        public string Storage { get; set; }
        public int Storage_id { get; set; }
        public string Product_id { get; set; }
        public int Variant_id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Ean { get; set; }
        public decimal Price_brutto { get; set; }
        public int Tax_rate { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}
