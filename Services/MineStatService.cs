using Microsoft.AspNetCore.Razor.TagHelpers;
using MineStatLib;

namespace vanilla_asterisk.Services;

public class MineStatService : IMcServerStatusService
{
    private string? ip;
    private ushort? port;
    private MineStat? ms;

    public bool IsOnline => ms?.ServerUp ?? throw new InvalidOperationException();
    public int OnlinePlayersCount => ms?.CurrentPlayersInt ?? throw new InvalidOperationException();
    public int MaxPlayersCount => ms?.MaximumPlayersInt ?? throw new InvalidOperationException();
    public long Ping => ms?.Latency ?? throw new InvalidOperationException();
    public string Motd => ms?.Stripped_Motd ?? throw new InvalidOperationException();
    public string Gamemode => ms?.Gamemode.ToString() ?? throw new InvalidOperationException();
    public string Ip => ip ?? throw new InvalidOperationException();
    public ushort Port => port ?? throw new InvalidOperationException();

    public void Connect(string ip, ushort port)
    {
        ms = new MineStat(ip, port);
    }

    public void Connect(string ip)
    {
        Connect(ip, 25565);
    }
}
