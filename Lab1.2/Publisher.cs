using System;

namespace Lab12
{
    public class Publisher
    {
        public Publisher(EventBus<EventMessage> eventBus)
        {
            this.eventBus = eventBus;
        }

        private readonly EventBus<EventMessage> eventBus;

        public void InitEvents()
        {
            eventBus.AddEvent("OnKeyK");
            eventBus.AddEvent("OnKeyT");
            eventBus.AddEvent("OnKeyQ");
            eventBus.AddEvent("OnKeyQ");

            eventBus.AddSubscriber("OnKeyK", (m) => Console.WriteLine($"\n{m.Message} - in publisher"));
        }

        public void Work()
        {
            ConsoleKey key = new();

            while (key != ConsoleKey.Q)
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.K : eventBus.InvokeEvent("OnKeyK", new EventMessageForK($"Key {key} pressed", "This message for K"));
                        break;
                    case ConsoleKey.T : eventBus.InvokeEvent("OnKeyT", new EventMessage($"Key {key} pressed"));
                        break;
                    case ConsoleKey.Q : eventBus.InvokeEvent("OnKeyQ", new EventMessage($"Key {key} pressed"));
                        break;
                }
            }
        }
    }
}
