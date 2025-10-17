using System.ComponentModel.DataAnnotations;

namespace vanilla_asterisk.Models;

public class PlayerStat
{
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public int Score { get; set; }

    [Required]
    public int PlayerId { get; set; }
    public required Player Player { get; set; }

    [Required]
    public int ScoreboardId { get; set; }
    public required Stat Scoreboard { get; set; }
}
