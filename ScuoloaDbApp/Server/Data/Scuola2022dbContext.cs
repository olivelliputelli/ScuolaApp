using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScuoloaDbApp.Shared;

namespace ScuoloaDbApp.Server.Data;

public partial class Scuola2022dbContext : DbContext
{
    public Scuola2022dbContext()
    {
    }

    public Scuola2022dbContext(DbContextOptions<Scuola2022dbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Classe> Classi { get; set; }

    public virtual DbSet<ClassiStudenti> ClassiStudenti { get; set; }

    public virtual DbSet<Studente> Studenti { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=Scuola_2022Db;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classe>(entity =>
        {
            entity.Property(e => e.Sigla).IsFixedLength();
        });

        modelBuilder.Entity<ClassiStudenti>(entity =>
        {
            entity.ToView("ClassiStudenti");

            entity.Property(e => e.Sigla).IsFixedLength();
        });

        modelBuilder.Entity<Studente>(entity =>
        {
            entity.Property(e => e.SiglaClasse).IsFixedLength();

            entity.HasOne(d => d.SiglaClasseNavigation).WithMany(p => p.Studenti)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Studenti_Classi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
