using System;

namespace BabysitterKata
{
    public class Babysitter
    {
        const int START_TIME_TO_BEDTIME_HOURLY_RATE = 12;
        const int BEDTIME_TO_MIDNIGHT_HOURLY_RATE = 8;
        const int MIDNIGHT_TO_END_TIME_HOURLY_RATE = 16;
        const int FOUR_AM_MILITARY_TIME = 4;
        const int FIVE_PM_MILITARY_TIME = 17;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BedTime { get; set; }

        private DateTime _midnight = DateTime.MinValue;
        private DateTime _minStartTime = DateTime.MinValue;
        private DateTime _maxEndTime = DateTime.MinValue;

        public int CalculatePay()
        {
            this.StartTime = RemoveMinutesAndSeconds(this.StartTime);
            this.EndTime = RemoveMinutesAndSeconds(this.EndTime);
            this.BedTime = RemoveMinutesAndSeconds(this.BedTime);

            InitializeTimeProperties();

            if (AreTimePropertiesValid())
            { 
                int payStartTimeToBedtime = CalcuatePayBeforeBedtime();
                int payBedtimeToMidnight = CalcuatePayFromBedtimeToMidnight();
                int payMidnightToEndTime = CalcuatePayFromMidnightToEndTime();

                return payStartTimeToBedtime + payBedtimeToMidnight + payMidnightToEndTime;
            }
            else
            {
                return 0;
            }
        }

        private bool AreTimePropertiesValid()
        {
            bool valid = true;

            if (this.BedTime < _minStartTime && _minStartTime < _midnight)
            {
                valid = false;
            }
            else if (this.BedTime > _maxEndTime)
            {
                valid = false;
            }
            else if (this.StartTime >= this.EndTime)
            {
                valid = false;
            }

            return valid;
        }

        private void InitializeTimeProperties()
        {
            _midnight = this.StartTime.Date;
            _minStartTime = this.StartTime;

            // if start time after 4 am then set midnight to next day midnight
            if (this.StartTime.Hour > FOUR_AM_MILITARY_TIME)
            {
                _midnight = _midnight.AddDays(1);
                _minStartTime = this.StartTime.Date.AddHours(FIVE_PM_MILITARY_TIME);
            }

            // make sure end time is 4 am or earlier
            _maxEndTime = _midnight.AddHours(FOUR_AM_MILITARY_TIME);
            if (this.EndTime > _maxEndTime)
            {
                this.EndTime = _maxEndTime;
            }

            // make sure start time is 5 pm or later
            if (this.StartTime < _minStartTime)
            {
                this.StartTime = _minStartTime;
            }
        }

        private int CalcuatePayBeforeBedtime()
        {
            TimeSpan timeSpanStartTimeToBedtime = TimeSpan.Zero;

            if (this.EndTime < this.BedTime)
            {
                timeSpanStartTimeToBedtime = this.EndTime - this.StartTime;
            }
            else if (this.StartTime < this.BedTime)
            {
                timeSpanStartTimeToBedtime = this.BedTime - this.StartTime;
            }

            return timeSpanStartTimeToBedtime.Hours * START_TIME_TO_BEDTIME_HOURLY_RATE;
        }

        private int CalcuatePayFromBedtimeToMidnight()
        {
            TimeSpan timeSpanBedtimeToMidnight = TimeSpan.Zero;

            if (this.StartTime < _midnight && this.EndTime > this.BedTime)
            {
                timeSpanBedtimeToMidnight = _midnight - this.BedTime;
            }

            return timeSpanBedtimeToMidnight.Hours * BEDTIME_TO_MIDNIGHT_HOURLY_RATE;
        }

        private int CalcuatePayFromMidnightToEndTime()
        {
            TimeSpan timeSpanMidnightToEndTime = TimeSpan.Zero;

            if (this.StartTime >= _midnight && this.EndTime >= _midnight)
            {
                timeSpanMidnightToEndTime = this.EndTime - _midnight;
            }
            else
            {
                if (this.EndTime > this.BedTime)
                {
                    timeSpanMidnightToEndTime = this.EndTime - _midnight;
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
