namespace vanilla_asterisk.Services;

public interface IScoreboardReader
{
    public void Open(string filename);
    public List<string> GetScoreboardNames();
}
