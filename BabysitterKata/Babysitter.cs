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

            TimeSpan ts = endTime - startTime;
            return ts.Hours * 12;
        }
    }
}
