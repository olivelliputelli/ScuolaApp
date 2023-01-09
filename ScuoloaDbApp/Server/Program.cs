using Microsoft.EntityFrameworkCore;
using ScuoloaDbApp.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Scuola2022dbContext>(opt => opt.UseSqlServer("Server=MSI\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=Scuola_2022Db;Trusted_Connection=True;"));

// builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
//app.UseStaticFiles();

app.MapGet("api/cs", async (Scuola2022dbContext db) =>
    await db.ClassiStudenti.ToListAsync());

app.MapGet("api/classi", async (Scuola2022dbContext db) =>
    await db.Classi.ToListAsync());

//app.UseRouting();

app.MapRazorPages();

// app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
