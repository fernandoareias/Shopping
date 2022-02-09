﻿using System;

namespace Shopping.Identidade.API.Shared.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get;  set; }

        protected Message()
        {
            MessageType = GetType().Name;

        }
    }
}
