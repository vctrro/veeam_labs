using System;
using System.Collections.Generic;

namespace Lab12
{
    public class Subscriber
    {
        public Subscriber(EventBus<string> eventBus)
        {
            eventNames = eventBus.GetAllEvents();

            foreach (var name in eventNames)
            {
                eventBus.AddSubscriber(name, Print);
            }

            eventBus.AddSubscriber("OnKeyM", (s) => Console.WriteLine($"\n{s} - in subscriber"));
        }

        private List<string> eventNames;

        public void Print(string s) => Console.WriteLine($"\n{s} at {DateTime.Now:F}");
    }
}
