﻿namespace Foxes.Game.Network.Events
{
    using Core;
    using JetBrains.Annotations;

    [PublicAPI]
    public readonly struct CreateRoomFailedEvent : IEvent
    {
        public short ReturnCode { get; }
        public string Message { get; }
        
        public CreateRoomFailedEvent(short returnCode, string message)
        {
            ReturnCode = returnCode;
            Message = message;
        }
    }
}