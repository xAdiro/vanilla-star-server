using System.ComponentModel.DataAnnotations;

namespace vanilla_asterisk.Models;

public class Stat
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required int CategoryId { get; set; }
    public required StatCategory Category { get; set; }

    public ICollection<PlayerStat> PlayerStats { get; set; } = [];
}
