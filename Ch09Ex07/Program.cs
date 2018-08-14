using System;
using System.Collections.Generic;

namespace Ch09Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            PropertyEventsSample p = new PropertyEventsSample();
            p.Event1 += Delegate1Method;
            p.Event1 += Delegate1Method;
            p.Event1 -= Delegate1Method;
            p.RaiseEvent1(2);
            p.Event2 += Delegate2Method;
            p.Event2 += Delegate2Method;
            p.Event2 -= Delegate2Method;
            p.RaiseEvent2("testString");
            Console.WriteLine("Hello World!");
        }
        public static void Delegate1Method(int i)
        {
            Console.WriteLine(i);
        }
        public static void Delegate2Method(string s)
        {
            Console.WriteLine(s);
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
                    eventTable.TryGetValue("Event1", out Delegate d);
                    eventTable["Event1"] = Delegate.Combine(d, value);
                }
            }
            remove
            {
                lock (eventTable)
                {
                    if(eventTable.TryGetValue("Event1", out Delegate d))
                    {
                        d = Delegate.Remove(d, value);
                        eventTable["Event1"] = d;
                    }
                    //eventTable["Event1"] = (EventHandler1)eventTable["Event1"] - value;
                }
            }
        }
        public event EventHandler2 Event2
        {
            add
            {
                lock (eventTable)
                {
                    eventTable.TryGetValue("Event2", out Delegate d);
                    eventTable["Event2"] = Delegate.Combine(d, value);
                }
            }
            remove
            {
                lock (eventTable)
                {
                    if (eventTable.TryGetValue("Event2", out Delegate d))
                    {
                        d = Delegate.Remove(d, value);
                        eventTable["Event2"] = d;
                    }
                    //eventTable["Event1"] = (EventHandler1)eventTable["Event1"] - value;
                }
            }
        }
        internal void RaiseEvent1(int i)
        {
            //EventHandler1 handler1;
            //if( null != (handler1 = (EventHandler1)eventTable["Event1"]))
            //{
            //    handler1(i);
            //}
            if(eventTable.TryGetValue("Event1", out Delegate d))
            {
                d?.DynamicInvoke(i);
            }
        }
        internal void RaiseEvent2(string s)
        {
            if(eventTable.TryGetValue("Event2", out Delegate d))
            {
                d?.DynamicInvoke(s);
            }
        }
    }
}
