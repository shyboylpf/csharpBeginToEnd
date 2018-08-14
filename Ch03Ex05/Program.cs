using System;

namespace Ch03Ex05
{
    class Program
    {
        static void Main1(string[] args)
        {
            object obj1;
            object obj2 = 23;
            object obj3 = 'A';
            object obj4 = 12.34;

            Console.WriteLine(obj2);
            Console.WriteLine(obj3);
            Console.WriteLine(obj4);
            Console.WriteLine("Hello World!");

            // Ch03Ex07
            int[] array1 = new int[] { 1, 2, 3, 4 };
            int[,] array2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,,] array3 = new int[2, 3, 4];
            int[][] array4 = new int[3][];
            array4[0] = new int[] { 1, 2, 3, 4 };
            array4[1] = new int[] { 1, 2, 3, 4, 5, 6 };
            array4[2] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            for(int i = 0; i< array1.Length; i++)
            {
                Console.WriteLine("array1[{0}] = {1}", i, array1[i]);
            }
            Console.ReadLine();

        }
    }

    public interface IPer { }

    interface INewInterface : IParent1, IParent2 {
        void Method1();
        void Method2();
        new void Method3();
    }

    public delegate int PerfromCalculation(int x, int y);

    public abstract class A
    {
        private int num = 0;
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public virtual int getNum()
        {
            return num;
        }
        public void setNum(int n)
        {
            this.num = n;
        }

        public abstract void E();

    }

    public abstract class B : A
    {
        
    }

    public class C : B
    {
        public override void E()
        {
            throw new NotImplementedException();
        }
    }

    public class Test
    {
        static void Main3()
        {
            C c = new C();
            c.E();
        }
    }

    public delegate void EventHandler(object sender, EventArgs e);

    public interface ITest
    {
        int A
        {
            get;set;
        }
        void Test();
        event EventHandler Event;
        int this[int index]
        {
            get;set;
        }
    }

    // Indexer on an interface:
    public interface ISomeInterface
    {
        // indexer declaration:
        int this[int index]
        {
            get;set;
        }
    }

    class IndexerClass : ISomeInterface
    {
        private int[] arr = new int[100];
        public int this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
        //string IEmployee.this[int index] { }
    }

    class MainClass1
    {
        static void Main4()
        {
            IndexerClass test = new IndexerClass();
            System.Random rand = new Random();
            // call the indexer to initialize its elements.
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for(int i=0; i<11; i++)
            {
                System.Console.WriteLine("Element #{0} = {1}", i, test[i]);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class TempRecord
    {
        // array of temperature values
        private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                                            61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

        // to enable client code to validate input
        // when accessing your indexer.
        public int Length
        {
            get { return temps.Length; }
        }
        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get { return temps[index]; }
            set { temps[index] = value; }
        }
    }
    class MainClass5
    {
        static void Main5()
        {
            TempRecord tempRecord = new TempRecord();
            // use the indexer's set accessor
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;

            // use the indexer's get accessor
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Element #{0} = {1}", i, tempRecord[i]);
            }

            // keep the console window open in debug mode.
            Console.WriteLine(tempRecord.Length);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    // using a string as an indexer value
    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        // This method finds the day or returns -1
        private int GetDay(string testDay)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == testDay)
                {
                    return j;
                }
            }
            throw new ArgumentOutOfRangeException(testDay, "testDay must be in the form \"Sun\", \"Mon\", etc");
        }
        public int this[string day]
        {
            get
            {
                return (GetDay(day));
            }
        }
    }
    class ClassMain
    {
        static void Main(string[] args)
        {
            DayCollection week = new DayCollection();
            Console.WriteLine(week["Fri"]);

            // Raise ArgumentOutOfRangeException
            Console.WriteLine(week["Make-up-day"]);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
