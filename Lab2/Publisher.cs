using System;

namespace Lab12
{
    public class Publisher
    {
        public Publisher(EventBus<string> eventBus)
        {
            this.eventBus = eventBus;
        }

        private readonly EventBus<string> eventBus;

        public void InitEvents()
        {
            eventBus.AddEvent("OnKeyK");
            eventBus.AddEvent("OnKeyT");
            eventBus.AddEvent("OnKeyQ");
            eventBus.AddEvent("OnKeyQ");

            eventBus.AddSubscriber("OnKeyK", (s) => Console.WriteLine($"\n{s} - in publisher"));
        }

        public void Work()
        {
            ConsoleKey key = new();

            while (key != ConsoleKey.Q)
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.K : eventBus.InvokeEvent("OnKeyK", "Key K pressed");
                        break;
                    case ConsoleKey.T : eventBus.InvokeEvent("OnKeyT", "Key T pressed");
                        break;
                    case ConsoleKey.Q : eventBus.InvokeEvent("OnKeyQ", "Key Q pressed");
                        break;
                }
            }
        }
    }
}
