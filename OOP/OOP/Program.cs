using System;
using System.Collections.Generic;

namespace OOP
{
    public enum _EventType
    {
        Coffee = 1,
        Lecture = 2,
        Concert = 3,
        StudySession = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<Event, List<Person>>();
            var action = 1;

            while (action != 0)
            {
                Console.WriteLine("Unesite broj akcije koju zelite izvrsiti: ");
                Console.WriteLine("1. Dodavanje eventa");
                Console.WriteLine("2. Brisanje eventa");
                Console.WriteLine("3. Edit eventa");
                Console.WriteLine("4. Dodavanje osobe na event");
                Console.WriteLine("5. Uklanjanje osobe sa eventa");
                Console.WriteLine("6. Ispis detalja eventa");
                Console.WriteLine("0. Izlaz iz aplikacije");
                
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        AddEvent(dict);
                        break;
                    case 2:
                        DeleteEvent(dict);
                        break;
                    case 3:
                        EditEvent(dict);
                        break;
                    default:
                        break;
                }
            }
        }
        static string Input(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static bool Sure(string message)
        {
            Console.WriteLine(message);
            var answear = "";
            do
            {
                Console.WriteLine("(y - da, n - ne)");
                answear = Console.ReadLine();
            } while ((answear != "y") && (answear != "n"));

            if (answear == "y")
                return true;
            else
                return false;
        }
        static bool EventNameExists(Dictionary<Event, List<Person>> dict, string eventName)
        {
            foreach (var _event in dict)
            {
                if (_event.Key.Name == eventName)
                    return true;
            }
            return false;
        }
        static void AddEvent(Dictionary<Event, List<Person>> dict)
        {
        Name:
            var eventName = Input("Unesite ime eventa koji zelite dodati.");
            if (eventName == "")
            {
                Console.WriteLine("Nemozete ime ostaviti prazno!");
                goto Name;
            }
            if (EventNameExists(dict, eventName))
            {
                Console.WriteLine("Event s tim imenom vec postoji.");
                goto Name;
            }
        Type:
            var eventType = int.Parse(Input("Unesite broj ispred tipa eventa kojeg zelite (1. Coffee, 2. Lecture, 3. Concert, 4. StudySession): "));
            if (eventType < 1 || eventType > 4)
            {
                Console.WriteLine("Unesite broj izmedu 1 i 4!");
                goto Type;
            }
        StartTime:
            var startTime = Input("Unesite vrijeme pocetka eventa ('dd/mm/yyyy hh:mm):");
            if (startTime == "")
            {
                Console.WriteLine("Morate unijeti pocetno vrijeme!");
                goto StartTime;
            }
            DateTime start = DateTime.Parse(startTime);
        EndTime:
            var endTime = Input("Unesite vrijeme zavrsetka eventa ('dd/mm/yyyy hh:mm'):");
            if (endTime == "")
            {
                Console.WriteLine("Morate unijeti zavrsno vrijeme!");
                goto EndTime;
            }
            DateTime end = DateTime.Parse(endTime);

            var newEvent = new Event(eventName, (_EventType)1, start, end);
            var listOfPeople = new List<Person>();

            Console.WriteLine("Jeste li sigurni da zelite dodati event '{0}( {1}, {2} - {3})'", eventName, eventType.ToString(), start.ToUniversalTime(), end.ToUniversalTime());
            if (Sure(""))
            {
                dict.Add(newEvent, listOfPeople);
            }
            else
            {
                Console.WriteLine("Stvaranje eventa prekinuto!");
                return;
            }
        }
        static void DeleteEvent(Dictionary<Event, List<Person>> dict)
        {
        start:
            var eventName = Input("Koji event zelite izbrisati(ime eventa)?");
            var tempDict = new Dictionary<Event, List<Person>>();
            foreach(var _event in dict)
            {
                if (_event.Key.Name == eventName)
                    break;
                else 
                {
                    Console.WriteLine("Unesite ime postojuceg eventa!");
                    goto start;
                }
            }
            if (Sure("Jeste li sigurni da zelite izbrisati taj event?"))
            {
                foreach (var _event in dict)
                {
                    if (_event.Key.Name == eventName)
                        dict.Remove(_event.Key);
                }
            }
            else 
            {
                Console.WriteLine("Brisanje eventa obustavljeno.");
            }
        }
        static void EditEvent(Dictionary<Event, List<Person>> dict)
        {
        start:
            var eventName = Input("Koji event zelite editati (ime eventa)?");
            if (eventName == "")
            {
                Console.WriteLine("Morate unijeti ime eventa!");
                goto start;
            }
        choice:
            var whatToEdit = int.Parse(Input("Sto zelite editati u tom eventu?(1 - ime, 2 - vrstu eventa, 3 - pocetno vrijeme, 4 - zavrsno vrijeme)"));
            if (whatToEdit < 1 || whatToEdit > 4)
            {
                Console.WriteLine("Morate unijeti broj izmedu 1 i 4!");
                goto choice;
            }

            switch (whatToEdit)
            {
                case 1:
                    var newEventName = Input("Unesite novo ime eventa: ");
                    if (newEventName == "")
                    {
                        Console.WriteLine("Morate unijeti ime eventa da bi ga promijenili!");
                        goto case 1;
                    }
                    if (EventNameExists(dict, newEventName))
                    {
                        Console.WriteLine("To ime eventa vec postoji!");
                        goto case 1;
                    }
                    foreach (var _event in dict)
                    {
                        if (_event.Key.Name == eventName)
                            _event.Key.Name = newEventName;
                    }
                    break;
                case 2:
                    var newEventType = int.Parse(Input("Unesite broj ispred tipa eventa kojeg zelite (1. Coffee, 2. Lecture, 3. Concert, 4. StudySession): "));
                    if (newEventType < 1 || newEventType > 4)
                    {
                        Console.WriteLine("Morate unijeti broj izmedu 1 i 4!");
                        goto case 2;
                    }
                    foreach (var _event in dict)
                    {
                        if (_event.Key.Name == eventName)
                        {
                            _event.Key.EventType = (_EventType)newEventType;
                        }
                    }
                    break;
                case 3:
                    var newStartTime = Input("Unesite novo vrijeme pocetka eventa ('dd/mm/yyyy hh:mm):");
                    if (newStartTime == "")
                    {
                        Console.WriteLine("Morate unijeti pocetno vrijeme!");
                        goto case 3;
                    }
                    foreach (var _event in dict)
                    {
                        if (_event.Key.Name == eventName)
                        {
                            if (_event.Key.EndTime > DateTime.Parse(newStartTime))
                                _event.Key.StartTime = DateTime.Parse(newStartTime);
                            else 
                            {
                                Console.WriteLine("Nemoze se unijeti pocetno vrijeme koje je poslije zavrsnog vremena eventa!");
                                Console.WriteLine("Unesite vrijeme prije " + _event.Key.EndTime.ToUniversalTime());
                                goto case 3;
                            }
                        }
                    }
                    break;
                case 4:
                    var newEndTime = Input("Unesite novo vrijeme zavrsno eventa ('dd/mm/yyyy hh:mm):");
                    if (newEndTime == "")
                    {
                        Console.WriteLine("Morate unijeti zavrsno vrijeme!");
                        goto case 4;
                    }
                    foreach (var _event in dict)
                    {
                        if (_event.Key.Name == eventName)
                        {
                            if (_event.Key.StartTime < DateTime.Parse(newEndTime))
                                _event.Key.EndTime = DateTime.Parse(newEndTime);
                            else
                            {
                                Console.WriteLine("Nemoze se unijeti zavrsno vrijeme koje je prije pocetnog vremena eventa!");
                                Console.WriteLine("Unesite vrijeme poslije " + _event.Key.StartTime.ToUniversalTime());
                                goto case 4;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        static void AddPersonToEvent(Dictionary<Event, List<Person>> dict)
        { 
            
        }
    }
}
