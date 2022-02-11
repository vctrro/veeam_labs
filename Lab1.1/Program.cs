using System;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Part 1. Immutable type\n");
            var im = new Immutable();
            void print() => Console.WriteLine("Object hash: \t{0}\nInstance hash: \t{1}", im.GetHashCode(), im.InstanceHash);
            print();
            im = new Immutable() { Name = "Pit", Age = 12 };
            print();
            im.Age = 13;
            print();
            im.Name = "Piter";
            print();

            Console.WriteLine("\nPart 2. Inheritance in struct\n");
            var baseStruct = new Base() { Name = "Parent"};
            baseStruct.PrintName();
            var derivedStruct = new Derived() { Name = "Child"};
            derivedStruct.PrintName();
            //derived = base
            derivedStruct = new Derived(baseStruct);
            derivedStruct.PrintName();
            derivedStruct.Name = "Child";
            baseStruct.PrintName();
            derivedStruct.PrintName();

        }
    }
}
