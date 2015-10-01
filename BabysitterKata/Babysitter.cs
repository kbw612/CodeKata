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
            int payStartTimeToBedtime = 0, payBedtimeToMidnight = 0;

            timeSpanStartTimeToBedtime = bedTime - startTime;
            timeSpanBedtimeToMidnight = endTime - bedTime;

            payStartTimeToBedtime = timeSpanStartTimeToBedtime.Hours * 12;
            payBedtimeToMidnight = timeSpanBedtimeToMidnight.Hours * 8;
            
            return payStartTimeToBedtime + payBedtimeToMidnight;
        }
    }
}
