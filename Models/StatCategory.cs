using System.ComponentModel.DataAnnotations;

namespace vanilla_asterisk.Models;

public class StatCategory
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string FriendlyName { get; set; }

    public ICollection<Stat> Stats {get;set;} = [];
}
