using System;
using System.Collections.Generic;
using System.Threading;

namespace shijian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

            twle.Foo += HandleFooEvent;

            twle.SimulateFoo();
        }

        private static void HandleFooEvent(object sender, FooEventArgs e)
        {
            Console.WriteLine("Handing Foo Event here...");
        }
    }
    // 11.4
    public sealed class EventKey : Object { }

    public sealed class EventSet
    {
        // 这个类的目的是在使用EventSet时, 提供多一点的类型安全性和可维护性
        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        // 添加一个EventKey -> Delegate映射(如果EventKey不存在)
        // 或者将一个委托与一个现有的EventKey合并
        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventKey, out Delegate d);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        // 从EventKey(如果存在)删除一个委托 并且在删除最后一个委托时删除EventKey-> Delegate映射
        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            // 调用TryGetValue , 确保在尝试从集合中删除一个不存在的EventKey时, 不会抛出异常
            if (m_events.TryGetValue(eventKey, out Delegate d))
            {
                d = Delegate.Remove(d, handler);
                if (d != null) m_events[eventKey] = d;
                else m_events.Remove(eventKey);
            }
            Monitor.Exit(m_events);
        }

        public void Raise(EventKey eventKey, Object sender, EventArgs e)
        {
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventKey, out Delegate d);
            Monitor.Exit(m_events);

            if (d != null)
            {
                d.DynamicInvoke(new Object[] { sender, e });
            }
        }
    }

    // 为这个事件定义从EventArgs派生的类型
    public class FooEventArgs : EventArgs { }

    public class TypeWithLotsOfEvents
    {
        private readonly EventSet m_eventSet = new EventSet();

        protected EventSet EventSet { get { return m_eventSet; } }

        #region 用于支持Foo事件的代码(为增加的事件重复这个模式)
        protected static readonly EventKey s_fooEventKey = new EventKey();

        public event EventHandler<FooEventArgs> Foo
        {
            add { m_eventSet.Add(s_fooEventKey, value); }
            remove { m_eventSet.Remove(s_fooEventKey, value); }
        }

        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_fooEventKey, this, e);
        }

        public void SimulateFoo() { OnFoo(new FooEventArgs()); }
        #endregion
    }


    // 事件的参数
    internal class NewMailEventArgs : EventArgs
    {
        private readonly String m_from, m_to, m_subject;

        public NewMailEventArgs(String from, String to, String subject)
        {
            m_from = from;
            m_to = to;
            m_subject = subject;
        }

        public String From { get { return m_from; } }
        public String To { get { return m_to; } }
        public String Subject { get { return m_subject; } }
    }

    internal class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        // 当有新邮件时 , 通知其他class
        // 往外发通知的
        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            //EventHandler<NewMailEventArgs> temp = Interlocked.CompareExchange(ref NewMail, null, null);
            //if (temp != null) temp(this, e);
            Interlocked.CompareExchange(ref NewMail, null, null)?.Invoke(this, e);
            e.Raise(this, ref NewMail);
        }

        public void SimulateNewMail(String from, String to, String subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }
    }

    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate) where TEventArgs : EventArgs
        {
            Interlocked.CompareExchange(ref eventDelegate, null, null)?.Invoke(sender, e);
        }
    }

    internal sealed class Fax
    {
        // 构造函数 , 将自己注册进NewMail
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }
        private void FaxMsg(Object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($"From = {e.From}, To={e.To}, Subject={e.Subject}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
            //mm.remove_NewMail(new EventHandler<NewMailEventArgs>(FaxMsg));
        }
    }
}
