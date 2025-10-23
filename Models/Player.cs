using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace vanilla_asterisk.Models;

[Index(nameof(UUID), IsUnique=true)]
public class Player
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string UUID { get; set; }

    public ICollection<PlayerStat> PlayerStats { get; set; } = [];
}
