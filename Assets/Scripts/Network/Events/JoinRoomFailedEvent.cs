namespace Foxes.Game.Network.Events
{
    using Core;
    using JetBrains.Annotations;

    [PublicAPI]
    public readonly struct JoinRoomFailedEvent : IEvent
    {
        public short ReturnCode { get; }
        public string Message { get; }
        
        public JoinRoomFailedEvent(short returnCode, string message)
        {
            ReturnCode = returnCode;
            Message = message;
        }
    }
}