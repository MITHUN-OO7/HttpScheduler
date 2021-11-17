using HttpBL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpBL.Repository
{
    public class Utility : IUtility
    {
        public TimeSpan GetIntervalatParticularTime()
        {
            TimeSpan interval;
            DateTime currentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"));
            DateTime nextDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-ddT23:58:00.fffffffK"));
            interval = nextDate - currentDate;
            return interval;
        }
        public int GetSecond()
        {
            var now = DateTime.Now.AddSeconds(-DateTime.Now.Second);
            int hours = 23 - now.Hour;
            int minutes = 58 - now.Minute;
            int seconds = 00;//59 - now.Second;
            int secondsTillMidnight = (hours * 3600) + (minutes * 60) + seconds;
            var hms = TimeSpan.FromSeconds(secondsTillMidnight);
            DateTime taskCallTime = now.AddHours(hms.Hours).AddMinutes(hms.Minutes).AddSeconds(-now.Second);
            Console.WriteLine(taskCallTime);
            return secondsTillMidnight;
        }
    }
}
