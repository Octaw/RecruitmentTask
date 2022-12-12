using RecruitmentTask.Models.Baselinker;
using RecruitmentTask.Models.Faire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Services.Abstract
{
    public interface IBaselinkerService
    {
        List<BaselinkerModel> mapTheData(List<FaireModel> listOfObjects);
        bool postOrders(List<BaselinkerModel> baselinkermodel);
    }
}
