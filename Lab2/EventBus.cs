using System.Linq;
using System.Collections.Generic;

namespace Lab12
{
    public class EventBus<T> where T : IEventMessage
    {
        public EventBus()
        {
            eventList = new();
        }

        public delegate void NewDelegate(T value);

        private readonly List<NewEvent> eventList;

        public void AddEvent(string name)
        {
            if (!eventList.Any(x => x.Name == name))
            eventList.Add(new NewEvent(name));
        }
        
        public void InvokeEvent(string name, T value)
        {
            var newEvent = eventList.Find(x => x.Name == name);
            if (newEvent != null)
            {
                newEvent.Invoked(value);
            }
        }

        public void AddSubscriber(string name, NewDelegate value)
        {
            var newEvent = eventList.Find(x => x.Name == name);
            if (newEvent == null)
            {
                newEvent = new NewEvent(name);
                eventList.Add(newEvent);
            }

            newEvent.Event += value;
        }

        public bool DelSubscriber(string name, NewDelegate value)
        {
            var newEvent = eventList.Find(x => x.Name == name);
            if (newEvent != null)
            {
                newEvent.Event -= value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DelEvent(string name)
        {
            eventList.Remove(eventList.Find(x => x.Name == name));
        }

        public List<string> GetAllEvents()
        {
            return eventList.Select(x => x.Name).ToList();
        }

        private class NewEvent
        {
            public NewEvent(string name)
            {
                Name = name;
            }

            public string Name { get; }
            public event NewDelegate Event;

            public void Invoked(T value)
            {
                Event?.Invoke(value);
            }
        }
    }
}
