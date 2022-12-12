using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Baselinker
{
    public class BaselinkerModel
    {
            public int Order_status_id { get; set; }
            public int Custom_source_id { get; set; }
            public DateTime Date_add { get; set; }
            public string User_comments { get; set; }
            public string Admin_comments { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string User_login { get; set; }
            public string Currency { get; set; }
            public string Payment_method { get; set; }
            public string Payment_method_cod { get; set; }
            public string Paid { get; set; }
            public string Delivery_method { get; set; }
            public string Delivery_price { get; set; }
            public string Delivery_fullname { get; set; }
            public string Delivery_company { get; set; }
            public string Delivery_address { get; set; }
            public string Delivery_city { get; set; }
            public string Delivery_postcode { get; set; }
            public string Delivery_country_code { get; set; }
            public string Delivery_point_id { get; set; }
            public string Delivery_point_name { get; set; }
            public string Delivery_point_address { get; set; }
            public string Delivery_point_postcode { get; set; }
            public string Delivery_point_city { get; set; }
            public string Invoice_fullname { get; set; }
            public string Invoice_company { get; set; }
            public string Invoice_nip { get; set; }
            public string Invoice_address { get; set; }
            public string Invoice_city { get; set; }
            public string Invoice_postcode { get; set; }
            public string Invoice_country_code { get; set; }
            public string Want_invoice { get; set; }
            public string Extra_field_1 { get; set; }
            public string Extra_field_2 { get; set; }
            public CustomExtraFields Custom_extra_fields { get; set; }
            public List<Product> Products { get; set; }
    }
}
