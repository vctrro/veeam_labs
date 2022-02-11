using System;
namespace Lab1_1_Immutable
{
    public struct Base
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public void PrintName()
        {
            Console.WriteLine("Base struct: {0}", Name);
        }
    }

    public struct Derived
    {
        public Derived(Base parent) { this.parent = parent; }

        private Base parent;

        public string Name { get => parent.Name; set => parent.Name = value; }

        public void PrintName()
        {
            Console.WriteLine("Derived struct: {0}", Name);
        }

    }
}
