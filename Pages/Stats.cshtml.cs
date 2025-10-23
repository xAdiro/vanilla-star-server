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
public class StatsModel(MinecraftDbContext context) : BasePageModel
{
    public required List<AliasedValue> Categories { get; set; }
    public required List<AliasedValue> Players { get; set; }


    private readonly MinecraftDbContext context = context;

    public async Task OnGetAsync()
    {
        Categories = await context.StatCategories.Select(category => new AliasedValue
        {
            FriendlyName = category.FriendlyName,
            Value = category.Name
        }).ToListAsync();
    }

    public async Task<IActionResult> OnGetStatsNamesAsync(string categoryName)
    {
        List<string> statsNames = await context.Stats.Include(s => s.Category)
            .Where(s => s.Category.Name == categoryName)
            .Select(s => s.Name)
            .ToListAsync();

        return new JsonResult(statsNames);
    }

    public async Task<IActionResult> OnGetPlayerStatsAsync(string categoryName, string statName)
    {
        var data = await context.Players
            .Include(p => p.PlayerStats)
            .ThenInclude(ps => ps.Stat)
            .ThenInclude(s => s.Category)
            .Select(p => new
            {
                p.Name,
                Stats = p.PlayerStats
                    .Where(ps => ps.Stat.Name == statName && ps.Stat.Category.Name == categoryName)
                    .Select(ps => new {ps.Value, ps.Date}).ToList()
            })
            .ToListAsync();
        return new JsonResult(data);
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
