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

            DateTime midnight = DateTime.MinValue;

            SetTimes(ref startTime, ref endTime, ref midnight);

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

        private void SetTimes(ref DateTime startTime, ref DateTime endTime, ref DateTime midnight)
        {
            midnight = startTime.Date;
            DateTime minStartTime = startTime;

            // if start time after 4 am then set midnight to next day midnight
            if (startTime.Hour > 4)
            {
                midnight = midnight.AddDays(1);
                minStartTime = startTime.Date.AddHours(17);
            }

            DateTime maxEndTime = midnight.AddHours(4);

            if (endTime > maxEndTime)
            {
                endTime = maxEndTime;
            }

            if (startTime < minStartTime)
            {
                startTime = minStartTime;
            }
        }
    }
}
