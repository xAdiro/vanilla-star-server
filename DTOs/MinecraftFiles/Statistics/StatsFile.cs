using Newtonsoft.Json;

namespace vanilla_asterisk.DTOs.MinecraftFiles.Statistics;

public class StatsFile
{
    [JsonProperty("stats")]
    public required Dictionary<string,Dictionary<string,int>> Stats { get; set; }
    public int DataVersion { get; set; }
}
