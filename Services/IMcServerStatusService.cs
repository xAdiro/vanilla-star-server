
namespace vanilla_asterisk.Services;

public interface IMcServerStatusService
{
    public void Connect(string ip, ushort port);
    int OnlinePlayersCount { get; }
    int MaxPlayersCount { get; }
    bool IsOnline { get; }
    long Ping { get; }
    string Motd { get; }
    string Gamemode { get; }
}
