using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vanilla_asterisk.Pages.Base;
using vanilla_asterisk.Services;

namespace vanilla_asterisk.Pages;

public class StatsModel(IMcServerStatusService mc) : BasePageModel(mc)
{
    public void OnGet()
    {
    }
}
