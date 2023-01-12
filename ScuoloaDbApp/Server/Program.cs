using Microsoft.EntityFrameworkCore;
using ScuoloaDbApp.Server.Data;
using ScuoloaDbApp.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Scuola2022dbContext>(opt => opt.UseSqlite("Data Source=ScuolaDb.db"));

// builder.Services.AddDbContext<Scuola2022dbContext>(opt => opt.UseSqlServer("Server=MSI\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=Scuola_2022Db;Trusted_Connection=True;"));

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
app.UseStaticFiles();

// Lista delle classi (tutte le informazioni della classe)
// con il numero degli studenti per ogni classe;
app.MapGet("api/cs", async (Scuola2022dbContext db) =>
    await db.ClassiStudenti.ToListAsync());

// CRUD tabella Classi
app.MapGet("api/classi", async (Scuola2022dbContext db) =>
    await db.Classi.ToListAsync());

app.MapGet("api/classi/{id}", async (string id, Scuola2022dbContext db) =>
{
    Classe? classe = await db.Classi.FindAsync(id);
    if (classe is not null)
        return Results.Ok(classe);
    else
        return Results.NotFound();
});

app.MapPost("api/classi", async (Classe classe, Scuola2022dbContext db) =>
{
    db.Classi.Add(classe);
    await db.SaveChangesAsync();

    return Results.Created($"api/classi/{classe.Sigla}", classe);
});

app.MapPut("api/classi/{id}", async (string id, Classe inputClasse, Scuola2022dbContext db) =>
{
    var classe = await db.Classi.FindAsync(id);

    if (classe is null) return Results.NotFound();

    classe.Sigla = inputClasse.Sigla;
    classe.Ubicazione = inputClasse.Ubicazione;
    classe.Note = inputClasse.Note;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/classi/{id}", async (string id, Scuola2022dbContext db) =>
{
    var classe = await db.Classi.FindAsync(id);
    if (classe is not null)
    {
        db.Classi.Remove(classe);
        await db.SaveChangesAsync();
        return Results.Ok(classe);
    }

    return Results.NotFound();
});

// CRUD tabella Studenti
app.MapGet("api/studenti", (Scuola2022dbContext db) =>
    db.Studenti.ToListAsync<Studente>());

//app.UseRouting();

app.MapRazorPages();

// app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
