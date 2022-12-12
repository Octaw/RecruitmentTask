using Newtonsoft.Json;
using RecruitmentTask.Models.Baselinker;
using RecruitmentTask.Models.Faire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.CompilerServices;
using RecruitmentTask.Services.Abstract;
using RecruitmentTask.Settings;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace RecruitmentTask.Services.Concrete
{
    public class BaselinkerServices: IBaselinkerService

    {
        private List<Product> MapForItems(List<Items> item)
        {
            List<Product> response = item.Select(i => new Product
            {
                Name = i.Product_name,
                Product_id = i.Product_id,
                Price_brutto = i.Price_cents
            }).ToList();

            return response;
        }
        public List<BaselinkerModel> mapTheData(List<FaireModel> listOfObjects)
        {

            List<BaselinkerModel> result = listOfObjects.Select(c => new BaselinkerModel
            {
                Order_status_id = 8069,
                Custom_source_id = 1024,
                Date_add = c.Created_at,
                Delivery_city = c.Address.City,
                Delivery_postcode = c.Address.Postal_code,
                Delivery_fullname = c.Address.Name,
                Delivery_address = c.Address.Address1,
                Delivery_country_code = c.Address.Country_code,
                Extra_field_1 = c.Id.ToString(),
                Phone = c.Address.Phone_number,
                Products = MapForItems(c.Item), 
            }).ToList();

            return result;
        }

        private string SerializeToJson(BaselinkerModel baselinker)
        {
            return JsonConvert.SerializeObject(baselinker);
        }

        public bool postOrders(List<BaselinkerModel> baselinkermodel)
        {
            foreach (var list in baselinkermodel)
            {
                postOrderJsonToBaselinker(SerializeToJson(list));
            }
            return true;
        }

        private bool postOrderJsonToBaselinker(string postData)
        {
            string baselinkerToken = Environment.GetEnvironmentVariable("X-BLToken");
            BaselinkerAccessToken bToken = JsonConvert.DeserializeObject<BaselinkerAccessToken>(baselinkerToken);
            if (bToken is null)
            {
                Console.WriteLine("Can not get a token");
                return false;
            }
            string postAddress = "https://api.baselinker.com/connector.php";
            string method = "addOrder";
            string curl = $"'{postAddress}' -H 'X-BLToken: {bToken.BaselinkerToken}' --data-raw 'method={method}&parameters={postData}'";
            using (var postClient = new RestClient(curl))
               {
                 var request = new RestRequest("", Method.Post);
                    var response = postClient.Execute(request);
                    var json = response.Content;
                    var data = JsonConvert.DeserializeObject<OutputData>(json);
                    if (data.Status == "SUCCESS")
                        Console.WriteLine("Order succesfull added");
                    else
                        Console.WriteLine("Order request failed");
                }
            return true;
        }
    }
}
