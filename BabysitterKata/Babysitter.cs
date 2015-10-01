using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class Babysitter
    {
        public int CalculatePay(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            return ts.Hours * 12;
        }
    }
}
