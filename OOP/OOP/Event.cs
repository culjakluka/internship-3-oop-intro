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
        public void PrintEvent() 
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Event name: " + Name);
            Console.WriteLine("Event type: " + (_EventType)EventType);
            Console.WriteLine("Event start time: " + StartTime.ToUniversalTime());
            Console.WriteLine("Event end time: " + EndTime.ToUniversalTime());
            Console.WriteLine("===================================");
        }
    }
}
