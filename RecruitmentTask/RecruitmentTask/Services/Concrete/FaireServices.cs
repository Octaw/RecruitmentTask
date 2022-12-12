using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RecruitmentTask.Services.Abstract;
using RecruitmentTask.Models.Faire;
using RecruitmentTask.Settings;
using RestSharp;
using RecruitmentTask.Models.Baselinker;

namespace RecruitmentTask.Services.Concrete
{
    public class FaireServices : IFaireService
    {
        public List<FaireModel> getOrdersJsonFromFaire()
        {
            string faireToken = Environment.GetEnvironmentVariable("X-FAIRE-ACCESS-TOKEN");
            FaireAccessToken token = JsonConvert.DeserializeObject<FaireAccessToken>(faireToken);

            if (token is null)
            {
                throw new Exception("Can not get a token");
            }
            List<FaireModel> listOfObjects = new();
            var address = "https://www.faire.com/api/v1";
            using (var restClient = new RestClient(address))
            {
                var request = new RestRequest("products", Method.Get);
                request.AddHeader("X-FAIRE-ACCESS-TOKEN", token.AccessToken);
                var response = restClient.Execute(request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("request failed");
                }
                var json = response.Content;
                listOfObjects = JsonConvert.DeserializeObject<List<FaireModel>>(json);
            }
            if (listOfObjects is null)
                throw new Exception("list of objects is empty");

            string baselinkerToken = Environment.GetEnvironmentVariable("X-BLToken");
            BaselinkerAccessToken bToken = JsonConvert.DeserializeObject<BaselinkerAccessToken>(baselinkerToken);
            if (bToken is null)
            {
                Console.WriteLine("Can not get a token");
            }
            string postAddress = "https://api.baselinker.com/connector.php";
            string checkMethod = "getOrders";
            string chechUrl = $"'{postAddress}' -H 'X-BLToken: {bToken.BaselinkerToken}' --data-raw 'method={checkMethod}'";
            List<CheckOutputData> checkData = new List<CheckOutputData>();
            using (var checkClient = new RestClient(chechUrl))
            {
                var chechRequest = new RestRequest("", Method.Get);
                var checkResponse = checkClient.Execute(chechRequest);
                var checkJson = checkResponse.Content;
                checkData = JsonConvert.DeserializeObject<List<CheckOutputData>>(checkJson);
            }
            /*foreach(var faireobject in listOfObjects)
            {
                foreach(var checkObject in checkData)
                {
                    if(faireobject.Id.Trim() == checkObject.Custom_extra_fields.extra_field_1.Trim())
                    {
                        listOfObjects.Remove(faireobject);
                    }
                }
            }
            */
            listOfObjects = listOfObjects.Where(c => !checkData.Any(d => d.Custom_extra_fields.extra_field_1.Trim() == c.Id.Trim())).ToList();

            return listOfObjects;
        }
    }
}
