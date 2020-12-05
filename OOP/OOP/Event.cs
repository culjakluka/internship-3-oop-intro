using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Event
    {

        public Event(string name, _EventType eventType, DateTime startTime, DateTime endTime)
        {
            Name = name;
            EventType = eventType;
            StartTime = startTime;
            EndTime = endTime;
        }
        public string Name { get; set; }
        public _EventType EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
