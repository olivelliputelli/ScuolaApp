using System.ComponentModel.DataAnnotations;

namespace ScuoloaDbApp.Shared;

public partial class Studente
{
    [Key]
    public int Matricola { get; set; }

    [StringLength(100)]
    public string Cognome { get; set; } = null!;

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    public string? Indirizzo { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    public bool Diplomato { get; set; }

    [StringLength(5)]
    public string SiglaClasse { get; set; } = null!;

    public virtual Classe SiglaClasseNavigation { get; set; } = null!;
}
