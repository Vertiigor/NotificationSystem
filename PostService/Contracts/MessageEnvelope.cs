﻿namespace NotificationSystem.Contracts
{
    public class MessageEnvelope
    {
        public string EventType { get; set; }
        public object Payload { get; set; }
    }
}
