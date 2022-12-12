using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecruitmentTask.Services.Abstract;
using RecruitmentTask.Services.Concrete;

namespace RecruitmentTask
{
    public class Main
    {
        [FunctionName("Main")]
        public void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var serviceProvider = new ServiceCollection()
            .AddScoped<IFaireService, FaireServices>()
            .AddScoped<IBaselinkerService, BaselinkerServices>()
            .AddScoped<IStartFaire, StartFaire>().BuildServiceProvider();
            var start = serviceProvider.GetService<IStartFaire>();

            start.Program();
        }
    }
}
