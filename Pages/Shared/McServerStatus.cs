using vanilla_asterisk.Pages.Base;
using vanilla_asterisk.Services;

namespace vanilla_asterisk.Pages.Shared;

public class McServerStatusModel(IMcServerStatusService mc) : BasePageModel
{
    public bool IsOnline { get; set; }
    public int MaxPlayers { get; set; }
    public int OnlinePlayers { get; set; }

    public void OnGet()
    {
        mc.Connect("mc.arostek.dev", 25565);
        IsOnline = mc.IsOnline;
        MaxPlayers = mc.MaxPlayersCount;
        OnlinePlayers = mc.OnlinePlayersCount;
    }
}
