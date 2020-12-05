using System;
using System.Collections.Generic;

namespace OOP
{
    public enum _EventType
    {
        Cofee,
        Lecture,
        Concert,
        StudySession
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<Event, List<Person>>();

        }
        static string Input(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
