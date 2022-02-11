using System;
using System.Collections.Generic;

namespace Lab1_2_Delegates
{
    public class Subscriber
    {
        public Subscriber(EventBus<EventMessage> eventBus)
        {
            eventNames = eventBus.GetAllEvents();

            foreach (var name in eventNames)
            {
                eventBus.AddSubscriber(name, Print);
                if (name == "OnKeyK") eventBus.AddSubscriber(name, PrintK);
            }

            eventBus.AddSubscriber("OnKeyM", (m) => Console.WriteLine($"\n{m.Message} - in subscriber"));
        }

        private List<string> eventNames;

        public void Print(IEventMessage m) => Console.WriteLine($"\n{m.Message} at {DateTime.Now:F}");
        public void PrintK(IEventMessage m) => Console.WriteLine($"\n{m.Message} at {DateTime.Now:F} / {(((EventMessageForK)m).AdditonalMessage)}");
    }
}
