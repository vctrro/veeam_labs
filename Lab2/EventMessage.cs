using System;
namespace Lab12
{
    public class EventMessage : IEventMessage
    {
        private readonly string message;

        public EventMessage(string message)
        {
            this.message = message;
        }

        public string Message => message;
    }

    public class EventMessageForK : EventMessage
    {
        public EventMessageForK(string message, string addMessage) : base(message)
        {
            AdditonalMessage = addMessage;
        }

        public string AdditonalMessage { get; }
    }
}
