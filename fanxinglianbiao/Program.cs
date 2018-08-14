using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using DateTimeList = System.Collections.Generic.List<System.DateTime>;

namespace fanxinglianbiao
{
    internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue> { }
    internal sealed class GenericTypeThatRequiresAnEnum<T>
    {
        static GenericTypeThatRequiresAnEnum()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }
    }
    public delegate TReturn CallMe<TReturn, TKey, TValue>(TKey key, TValue value);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ValueTypePerTest();
            ReferenceTypePerTest();

            Byte[] byteArray = new byte[] { 5, 1, 4, 2, 3 };

            Array.Sort<Byte>(byteArray);

            Int32 i = Array.BinarySearch<Byte>(byteArray, 1);
            Console.WriteLine(i);

            Object o = null;

            // 尝试创建该类型的一个实例(失败)
            Type t = typeof(Dictionary<,>);
            o = CreateInstance(t);
            Console.WriteLine();

            // 有一个类型参数 , 不过也是开房类型
            t = typeof(DictionaryStringKey<>);
            o = CreateInstance(t);

            // 封闭类型 , 成了
            t = typeof(DictionaryStringKey<Guid>);
            o = CreateInstance(t);

            // 证明它确实能够工作
            Console.WriteLine("对象类型 = " + o.GetType());

            GenericTypeThatRequiresAnEnum<EnumExm> gt = new GenericTypeThatRequiresAnEnum<EnumExm>();
            SameDataLinkedList();

            DifferentDataLinkedList();

            List<DateTime> dt = new List<DateTime>();
            DateTimeList dt2 = new DateTimeList();

            //dynamic d =null ;
            //d.M(1);



        }

        private enum EnumExm
        {
            a, b, c
        }

        #region 链表
        /// <summary>
        /// 链表 说实话 , 操作有点骚
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal sealed class Node<T>
        {
            public T m_data;
            public Node<T> m_next;
            public Node(T data) : this(data, null) { }

            public Node(T data, Node<T> next)
            {
                m_data = data;
                m_next = next;
            }
            public override string ToString()
            {
                return m_data.ToString() + m_next?.ToString();
            }
        }
        // 构建一个链表
        private static void SameDataLinkedList()
        {
            Node<Char> head = new Node<char>('C');
            head = new Node<char>('B', head);
            head = new Node<char>('A', head);
            Console.WriteLine(head.ToString());
        }
        #endregion

        #region 链表改进版
        internal class Node
        {
            protected Node m_next;
            public Node(Node next)
            {
                m_next = next;
            }
        }
        internal sealed class TypedNode<T> : Node
        {
            public T m_data;
            public TypedNode(T data) : this(data, null) { }
            public TypedNode(T data, Node next) : base(next)
            {
                m_data = data;
            }
            public override string ToString()
            {
                return m_data.ToString() + m_next?.ToString();
            }
        }
        // 构建一个链表
        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            Console.WriteLine(head.ToString());
        }
        #endregion

        //internal sealed class DateTimeList : List<DateTime> { }

        private static Object CreateInstance(Type t)
        {
            Object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Console.WriteLine($"已创建{t.ToString()}的实例");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return o;
        }



        private static void ReferenceTypePerTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<String>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X");
                    String x = l[n];
                }
                l = null;
            }
            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (int n = 0; n < count; n++)
                {
                    a.Add("X");
                    String x = (String)a[n];
                }
                a = null;
            }
        }

        private static void ValueTypePerTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<int>(count);
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n);
                    Int32 x = l[n];
                }
                l = null;
            }

            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (int n = 0; n < count; n++)
                {
                    a.Add(n);
                    int x = (int)a[n];
                }
                a = null;
            }
        }
    }

    internal sealed class OperationTimer : IDisposable
    {
        private Int64 m_startTime;
        private String m_text;
        private Int32 m_collectionCount;

        public OperationTimer(string text)
        {
            PrepareForOperation();

            m_text = text;
            m_collectionCount = GC.CollectionCount(0);

            m_startTime = Stopwatch.GetTimestamp();
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void Dispose()
        {
            Console.WriteLine("{0,6:###.00} seconds (GCs={1,3}) {2}",
                (Stopwatch.GetTimestamp() - m_startTime) /
                (Double)Stopwatch.Frequency,
                GC.CollectionCount(0) - m_collectionCount, m_text);
        }
    }
}
