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

        private DateTime _startTime = DateTime.MinValue;
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = RemoveMinutesAndSeconds(value);
            }
        }

        private DateTime _endTime = DateTime.MinValue;
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = RemoveMinutesAndSeconds(value);
            }
        }

        private DateTime _bedTime = DateTime.MinValue;
        public DateTime BedTime
        {
            get
            {
                return _bedTime;
            }
            set
            {
                _bedTime = RemoveMinutesAndSeconds(value);
            }
        }

        private DateTime _midnight = DateTime.MinValue;
        public DateTime Midnight
        {
            get
            {
                return _midnight;
            }
            set
            {
                _midnight = RemoveMinutesAndSeconds(value);
            }
        }

        private DateTime _minStartTime = DateTime.MinValue;
        public DateTime MinStartTime
        {
            get
            {
                return _minStartTime;
            }
            set
            {
                _minStartTime = RemoveMinutesAndSeconds(value);
            }
        }

        private DateTime _maxEndTime = DateTime.MinValue;
        public DateTime MaxEndTime
        {
            get
            {
                return _maxEndTime;
            }
            set
            {
                _maxEndTime = RemoveMinutesAndSeconds(value);
            }
        }

        public int CalculatePay()
        {
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

            if (this.BedTime < this.MinStartTime && this.MinStartTime < this.Midnight)
            {
                valid = false;
            }
            else if (this.BedTime > this.MaxEndTime)
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
            this.Midnight = this.StartTime.Date;
            this.MinStartTime = this.StartTime;

            // if start time after 4 am then set midnight to next day midnight
            if (this.StartTime.Hour > FOUR_AM_MILITARY_TIME)
            {
                this.Midnight = this.Midnight.AddDays(1);
                this.MinStartTime = this.StartTime.Date.AddHours(FIVE_PM_MILITARY_TIME);
            }

            // make sure end time is 4 am or earlier
            this.MaxEndTime = this.Midnight.AddHours(FOUR_AM_MILITARY_TIME);
            if (this.EndTime > this.MaxEndTime)
            {
                this.EndTime = this.MaxEndTime;
            }

            // make sure start time is 5 pm or later
            if (this.StartTime < this.MinStartTime)
            {
                this.StartTime = this.MinStartTime;
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

            if (this.StartTime < this.Midnight && this.EndTime > this.BedTime)
            {
                timeSpanBedtimeToMidnight = this.Midnight - this.BedTime;
            }

            return timeSpanBedtimeToMidnight.Hours * BEDTIME_TO_MIDNIGHT_HOURLY_RATE;
        }

        private int CalcuatePayFromMidnightToEndTime()
        {
            TimeSpan timeSpanMidnightToEndTime = TimeSpan.Zero;

            if (this.StartTime >= this.Midnight && this.EndTime >= this.Midnight)
            {
                timeSpanMidnightToEndTime = this.EndTime - this.Midnight;
            }
            else
            {
                if (this.EndTime > this.BedTime)
                {
                    timeSpanMidnightToEndTime = this.EndTime - this.Midnight;
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
