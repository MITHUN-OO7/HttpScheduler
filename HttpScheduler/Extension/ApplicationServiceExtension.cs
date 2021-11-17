using HttpBL;
using HttpBL.IRepository;
using HttpBL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpScheduler.Extension
{
    public static class ApplicationServiceExtension
    {
        #region Application services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerWorker, SchedulerWorker>();

            services.AddSingleton<ISchedulerWorker, SchedulerWorker>();
            services.AddSingleton<IUtility, Utility>();
            return services;
        }
        #endregion
    }
}
