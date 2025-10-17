using Microsoft.EntityFrameworkCore;
using vanilla_asterisk.Data;
using vanilla_asterisk.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorPages();
builder.Services.AddScoped<IMcServerStatusService, MineStatService>();
builder.Services.AddScoped<IScoreboardReader, FNBTScoreboardReader>();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

// export ConnectionStrings__DefaultConnection="Host=192.168.0.3;Database=vanilla_scores;Username=vanilla_asterisk;Password=<password>"
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No connection string env variable found");

builder.Services.AddDbContext<MinecraftDbContext>(options =>
        options.UseNpgsql(connectionString));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseResponseCompression();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
