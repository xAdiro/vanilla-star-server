using System.ComponentModel.DataAnnotations;

namespace vanilla_asterisk.Models;

public class Player
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string UUID { get; set; }

    public ICollection<PlayerStat> PlayerStats { get; set; } = [];
}
