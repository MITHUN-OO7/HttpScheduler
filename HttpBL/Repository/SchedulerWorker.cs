using HttpBL.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpBL.Repository
{
    public class SchedulerWorker : ISchedulerWorker
    {
         
        private readonly ILogger<SchedulerWorker> _logger;
        private readonly IUtility _utility;

        public SchedulerWorker(ILogger<SchedulerWorker> logger, IUtility utility)
        {
            _logger = logger;
            _utility = utility;
        }
        public async Task Scheduler(CancellationToken cancellationToken)
        {
            //you can set first hit on at particular time as you wish
            _utility.GetSecond();
            int callTime = Convert.ToInt32(30);

            await Task.Delay(TimeSpan.FromSeconds(callTime), cancellationToken);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Sechduler 1:- " + DateTime.Now.ToString("hh:mm:ss"));
                    _logger.LogInformation("Scheduler one called at:- " + DateTime.Now.ToString());
                    await Task.Delay(TimeSpan.FromSeconds(callTime), cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Scheduler Error at:- " + DateTime.Now.ToString(), ex);
            }
        }

        public async Task SchedulerTwo(CancellationToken cancellationToken)
        {
            int callTime = Convert.ToInt32(60);

            await Task.Delay(TimeSpan.FromSeconds(callTime), cancellationToken);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Sechduler 2:- " + DateTime.Now.ToString("hh:mm:ss"));
                    _logger.LogInformation("Scheduler two called at:- " + DateTime.Now.ToString());
                    await Task.Delay(TimeSpan.FromSeconds(callTime), cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Scheduler Error at:- " + DateTime.Now.ToString(), ex);

            }
        }
    }
}
