using System;
using System.Collections.Generic;

namespace AoC2018.Helpers.Day04
{
    class TimeEntry
    {
        public Guard Guard { get; set;}
        public DateTime BeginsShift { get; set; }

    }

    class Guard
    {
        public int ID { get; set; }
        public int SleepTime { get; set; }
        public List<Time> Times { get; set; }
    }

    class Time
    {
        public int Minute { get; set; }
        public int SleptTime { get; set; }
    }
}
