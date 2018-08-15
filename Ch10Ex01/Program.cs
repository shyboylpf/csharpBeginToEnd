using System;
using System.Collections.Generic;

namespace Ch10Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for(int x=0; x<10; x++)
            {
                list.AddHead(x);
            }
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Hello World!");
        }
    }

    public class GenericList<T>
    {
        private class Node
        {
            public Node(T t)
            {
                next = null;
                data = t;
            }
            private Node next;
            public Node Next {
                get { return next; }
                set { next = value; }
            }
            private T data;
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        private Node head;
        public GenericList()
        {
            head = null;
        }
        public void AddHead(T t)
        {
            Node n = new Node(t);  // 建新块
            n.Next = head;  // 新快链接旧块
            head = n;  // 移动头指针.
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while(current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
