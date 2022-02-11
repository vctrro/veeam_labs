using System;

namespace Lab12
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lab 1.2 - EventBus\n");
            EventBus<string> eventBus = new();
            print();
            Publisher publisher = new(eventBus);
            publisher.InitEvents();
            print();
            Subscriber subscriber = new(eventBus);
            print();
            publisher.Work();

            void print() {
                Console.WriteLine("List of Events");
                foreach (var item in eventBus.GetAllEvents())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            };
        }
    }
}
