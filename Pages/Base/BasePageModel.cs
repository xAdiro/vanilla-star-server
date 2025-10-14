using Microsoft.AspNetCore.Mvc.RazorPages;
using vanilla_asterisk.Services;

namespace vanilla_asterisk.Pages.Base;

public class BasePageModel : PageModel
{
    public required bool IsOnline { get; set; }
    public required int MaxPlayers { get; set; }
    public required int OnlinePlayers { get; set; }

    public BasePageModel(IMcServerStatusService mc)
    {
        mc.Connect("mc.arostek.pl", 25565);
        IsOnline = mc.IsOnline;
        MaxPlayers = mc.MaxPlayersCount;
        OnlinePlayers = mc.OnlinePlayersCount;
    }
}
