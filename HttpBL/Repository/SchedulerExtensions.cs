using HttpBL.IRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpBL.Repository
{
    public class SchedulerExtensions : IHostedService
    {
        private readonly ILogger<SchedulerExtensions> _logger;
        private readonly ISchedulerWorker _worker;

        public SchedulerExtensions(ILogger<SchedulerExtensions> logger, ISchedulerWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("service has been  started at :- " + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"));
            Task.Factory.StartNew(() => _worker.Scheduler(cancellationToken), cancellationToken);
            Task.Factory.StartNew(() => _worker.SchedulerTwo(cancellationToken), cancellationToken);
            //return _worker.SchedulerTaskforEDI(cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service has stopped at :-" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"));
            return Task.CompletedTask;
        }
    }
}
