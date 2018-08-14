using System;

namespace Ch07Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal duck = new Duck("Duck");
            duck.MakeVoice();
            duck.Show();
            Animal dog = new Dog("Dog");
            dog.MakeVoice();
            dog.Show();
            IAction dogAction = new Dog("A big dog");
            dogAction.Move();
            Console.WriteLine("Hello World!");
        }
    }
    public abstract class Animal
    {
        protected string name;
        public abstract string Name
        {
            get;
        }
        public abstract void Show();
        public void MakeVoice()
        {
            Console.WriteLine("所有动物都会叫!");
        }
    }
    public interface IAction
    {
        void Move();
    }

    public class Duck : Animal , IAction
    {
        public Duck(string name)
        {
            this.name = name;
        }
        public override void Show()
        {
            Console.WriteLine(Name + "is showing for you.");
        }
        // interface
        public void Move()
        {
            Console.WriteLine("Duck also can swim.");
        }

        public override string Name
        {
            get { return name; }
        }
    }
    public class Dog : Animal , IAction
    {
        public override string Name => throw new NotImplementedException();

        public Dog(string name)
        {
            this.name = name;
        }

        public override void Show()
        {
            Console.WriteLine(name + " is showing for you .");
        }

        public void Move()
        {
            Console.WriteLine("dog 会跑");
        }
    }
}
