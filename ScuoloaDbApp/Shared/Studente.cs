using System.ComponentModel.DataAnnotations;

namespace ScuoloaDbApp.Shared;

public class Studente
{
    [Key]
    public int Matricola { get; set; }
    public string Cognome { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string? Indirizzo { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public bool Diplomato { get; set; }
    public string ClasseSigla { get; set; } = null!;
    public Classe Classe { get; set; } = null!;
}
