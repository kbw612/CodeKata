using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class Babysitter
    {
        const int START_TIME_TO_BEDTIME_HOURLY_RATE = 12;
        const int BEDTIME_TO_MIDNIGHT_HOURLY_RATE = 8;
        const int MIDNIGHT_TO_END_TIME_HOURLY_RATE = 16;

        public int CalculatePay(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            DateTime midnight = DateTime.MinValue;

            startTime = RemoveMinutesAndSeconds(startTime);
            endTime = RemoveMinutesAndSeconds(endTime);
            bedTime = RemoveMinutesAndSeconds(bedTime);

            SetTimes(ref startTime, ref endTime, ref midnight);

            int payStartTimeToBedtime = CalcuatePayBeforeBedtime(startTime, endTime, bedTime);
            int payBedtimeToMidnight = CalcuatePayFromBedtimeToMidnight(startTime, endTime, bedTime, midnight);
            int payMidnightToEndTime = CalcuatePayFromMidnightToEndTime(startTime, endTime, bedTime, midnight);

            return payStartTimeToBedtime + payBedtimeToMidnight + payMidnightToEndTime;
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

            // make sure end time is 4 am or earlier
            DateTime maxEndTime = midnight.AddHours(4);
            if (endTime > maxEndTime)
            {
                endTime = maxEndTime;
            }

            // make sure start time is 5 pm or later
            if (startTime < minStartTime)
            {
                startTime = minStartTime;
            }
        }

        private int CalcuatePayBeforeBedtime(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            TimeSpan timeSpanStartTimeToBedtime = TimeSpan.Zero;

            if (endTime < bedTime)
            {
                timeSpanStartTimeToBedtime = endTime - startTime;
            }
            else if (startTime < bedTime)
            {
                timeSpanStartTimeToBedtime = bedTime - startTime;
            }

            return timeSpanStartTimeToBedtime.Hours * START_TIME_TO_BEDTIME_HOURLY_RATE;
        }

        private int CalcuatePayFromBedtimeToMidnight(DateTime startTime, DateTime endTime, DateTime bedTime, DateTime midnight)
        {
            TimeSpan timeSpanBedtimeToMidnight = TimeSpan.Zero;

            if (startTime < midnight && endTime > bedTime)
            {
                timeSpanBedtimeToMidnight = midnight - bedTime;
            }

            return timeSpanBedtimeToMidnight.Hours * BEDTIME_TO_MIDNIGHT_HOURLY_RATE;
        }

        private int CalcuatePayFromMidnightToEndTime(DateTime startTime, DateTime endTime, DateTime bedTime, DateTime midnight)
        {
            TimeSpan timeSpanMidnightToEndTime = TimeSpan.Zero;

            if (startTime >= midnight && endTime >= midnight)
            {
                timeSpanMidnightToEndTime = endTime - midnight;
            }
            else
            {
                if (endTime > bedTime)
                {
                    timeSpanMidnightToEndTime = endTime - midnight;
                }
            }

            return timeSpanMidnightToEndTime.Hours * MIDNIGHT_TO_END_TIME_HOURLY_RATE;
        }

        private DateTime RemoveMinutesAndSeconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
        }
    }
}
