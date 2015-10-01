using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class Babysitter
    {
        public int CalculatePay(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            TimeSpan timeSpanStartTimeToBedtime = TimeSpan.Zero;
            TimeSpan timeSpanBedtimeToMidnight = TimeSpan.Zero;
            TimeSpan timeSpanMidnightToEndTime = TimeSpan.Zero;
            int payStartTimeToBedtime = 0, payBedtimeToMidnight = 0, payMidnightToMaxEndTime = 0;

            DateTime midnight = startTime.Date;

            // if start time after 4 am then set midnight to next day midnight
            if (startTime.Hour > 4)
            {
                midnight = midnight.AddDays(1);
            }

            if (endTime < bedTime)
            {
                timeSpanStartTimeToBedtime = endTime - startTime;
            }
            else
            {
                timeSpanStartTimeToBedtime = bedTime - startTime;
            }

            if (endTime > bedTime) {
                timeSpanBedtimeToMidnight = midnight - bedTime;
                timeSpanMidnightToEndTime = endTime - midnight;
            }

            payStartTimeToBedtime = timeSpanStartTimeToBedtime.Hours * 12;
            payBedtimeToMidnight = timeSpanBedtimeToMidnight.Hours * 8;
            payMidnightToMaxEndTime = timeSpanMidnightToEndTime.Hours * 16;

            return payStartTimeToBedtime + payBedtimeToMidnight + payMidnightToMaxEndTime;
        }
    }
}
