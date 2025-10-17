
using fNbt;
namespace vanilla_asterisk.Services;

public class FNBTScoreboardReader : IScoreboardReader
{
    private string filename;
    private NbtFile file;
    private NbtCompound root;
    private NbtCompound data;


    public void Open(string filename)
    {
        this.filename = filename;
        file = new NbtFile(filename);
        root = file.RootTag;
        data = root.Get<NbtCompound>("data") ?? throw new InvalidOperationException("No data in file");
    }

    public List<string> GetScoreboardNames()
    {
        NbtList objectives = data.Get<NbtList>("Objectives");
        if (objectives is null) return [];

        List<string> names = [];

        foreach (NbtCompound objective in objectives)
        {
            string name = objective.Get<NbtString>("Name")?.Value ?? "Unknown";
            string criteria = objective.Get<NbtString>("CriteriaName")?.Value ?? "Unknown";
            string displayName = objective.Get<NbtString>("DisplayName")?.Value ?? name;

            if (name.StartsWith("ts_"))
            {
                names.Add(name[3..]);
            }
        }

        names.Sort();
        return names;
    }
}
