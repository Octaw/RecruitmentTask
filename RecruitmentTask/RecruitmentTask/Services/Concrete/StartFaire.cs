using Newtonsoft.Json;
using RecruitmentTask.Models.Baselinker;
using RecruitmentTask.Services.Abstract;
using RecruitmentTask.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Services.Concrete
{
    public class StartFaire : IStartFaire
    {
        private readonly IFaireService _faireService;
        private readonly IBaselinkerService _baselinkerService;

        public StartFaire(IFaireService faireService,
            IBaselinkerService baselinkerService)
        {   
            _faireService = faireService;
            _baselinkerService = baselinkerService;
        }
        public void Program()
        {
            var items = _faireService.getOrdersJsonFromFaire();
            List<BaselinkerModel> mapedItems = new();
            if(items is not null) 
            {
                try
                {
                    mapedItems = _baselinkerService.mapTheData(items);
                    if(!_baselinkerService.postOrders(mapedItems))
                    {
                        throw new Exception("Can't send a post requests");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
