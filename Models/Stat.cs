using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace vanilla_asterisk.Models;

[Index(nameof(Name), nameof(CategoryId), IsUnique = true)]
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
