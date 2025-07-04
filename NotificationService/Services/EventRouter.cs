﻿using NotificationSystem.Contracts;
using NotificationSystem.Services.Abstractions;
using NotificationSystem.Services.EventHandlers;

namespace NotificationSystem.Services
{
    public class EventRouter
    {
        private readonly Dictionary<string, IEventHandler> _handlers;

        public EventRouter(IServiceProvider serviceProvider)
        {
            // register handlers
            _handlers = new Dictionary<string, IEventHandler>
            {
                { "PostCreated", serviceProvider.GetRequiredService<PostCreatedHandler>() },
                { "PostDeleted", serviceProvider.GetRequiredService<PostDeletedHandler>() }
            };
        }

        public async Task RouteAsync(MessageEnvelope envelope)
        {
            if (_handlers.TryGetValue(envelope.EventType, out var handler))
            {
                await handler.HandleAsync(envelope);
            }
            else
            {
                Console.WriteLine($"⚠️ No handler registered for event type: {envelope.EventType}");
            }
        }
    }
}
