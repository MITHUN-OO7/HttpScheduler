using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpBL.IRepository
{
    public interface ISchedulerWorker
    {
        Task Scheduler(CancellationToken cancellationToken);
        Task SchedulerTwo(CancellationToken cancellationToken);
    }
}
