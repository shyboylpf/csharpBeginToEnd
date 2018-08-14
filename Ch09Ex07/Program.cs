using System;
using System.Collections.Generic;

namespace Ch09Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public delegate void EventHandler1(int i);
    public delegate void EventHandler2(string s);
    public class PropertyEventsSample
    {
        private Dictionary<string, Delegate> eventTable;
        public PropertyEventsSample()
        {
            eventTable = new Dictionary<string, Delegate>();
            eventTable.Add("Event1", null);
            eventTable.Add("Event2", null);
        }
        public event EventHandler1 Event1
        {
            add
            {
                lock(eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] - value;
                }
            }
        }
    }
}
