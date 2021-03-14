namespace Foxes.Game.Network
{
    public interface INetworkService
    {
        void JoinLobby();
        
        void CreateRoom(string room);
        
        void JoinRoom(string room);
    }
}