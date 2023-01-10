using Microsoft.EntityFrameworkCore;
using ScuoloaDbApp.Shared;

namespace ScuoloaDbApp.Server.Data;
public partial class Scuola2022dbContext : DbContext
{
    public Scuola2022dbContext(){}
    public Scuola2022dbContext(DbContextOptions<Scuola2022dbContext> options)
        : base(options){}
    public DbSet<Classe> Classi { get; set; }
    public DbSet<ClassiStudenti> ClassiStudenti { get; set; }
    public DbSet<Studente> Studenti { get; set; }
}
