using Microsoft.EntityFrameworkCore;
using vanilla_asterisk.Models;

namespace vanilla_asterisk.Data;

public class MinecraftDbContext(DbContextOptions<MinecraftDbContext> options) : DbContext(options)
{

    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStat> PlayerStats { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<StatCategory> StatCategories { get; set; }
}
