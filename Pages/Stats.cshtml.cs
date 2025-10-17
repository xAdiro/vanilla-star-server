using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using vanilla_asterisk.Data;
using vanilla_asterisk.DTOs.MinecraftFiles.Statistics;
using vanilla_asterisk.DTOs.Pages.Stats;
using vanilla_asterisk.Models;
using vanilla_asterisk.Pages.Base;
using vanilla_asterisk.Services;

namespace vanilla_asterisk.Pages;

[BindProperties]
public class StatsModel(IScoreboardReader sr, MinecraftDbContext context) : BasePageModel
{
    public required List<AliasedValue> Categories { get; set; }
    public required List<AliasedValue> Players { get; set; }
    private readonly IScoreboardReader sr = sr;
    private readonly MinecraftDbContext context = context;

    public async Task OnGetAsync()
    {
        Categories = await context.StatCategories.Select(category => new AliasedValue
        {
            FriendlyName = category.FriendlyName,
            Value = category.Name
        }).ToListAsync();
    }

    [Obsolete]
    private void SaveCategoriesToDb()
    {
        string path = @"resources/stats.json";

        string json = System.IO.File.ReadAllText(path);
        StatsFile stats = JsonConvert.DeserializeObject<StatsFile>(json) ?? throw new Exception();


        const int prefixLength = 10;
        List<string> categories = stats.Stats.Keys.Select(key => key.ToString()).ToList();

        foreach (string category in categories)
        {
            context.StatCategories.Add(new StatCategory
            {
                Name = category,
                FriendlyName = category.Substring(prefixLength).Replace("_", "")
            });
        }

        context.SaveChanges();
    }
}
