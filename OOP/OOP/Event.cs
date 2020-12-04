using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Event
    {

        public Event(string name, string eventType, DateTime startTime, DateTime endTime)
        {
            Name = name;
            EventType = eventType;
            StartTime = startTime;
            EndTime = endTime;
        }
        public string Name { get; set; }
        public string EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
