using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace vanilla_asterisk.Models;

[Index(nameof(Value), nameof(PlayerId), nameof(StatId),IsUnique = true)]
public class PlayerStat
{
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public int Value { get; set; }

    [Required]
    public int PlayerId { get; set; }
    public required Player Player { get; set; }

    [Required]
    public int StatId { get; set; }
    public required Stat Stat { get; set; }
}
