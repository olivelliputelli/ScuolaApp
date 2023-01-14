using System.ComponentModel.DataAnnotations;
namespace ScuoloaDbApp.Shared;
public partial class Classe
{
    [Key]
    [StringLength(5)]
    public string Sigla { get; set; } = null!;
    public string Ubicazione { get; set; } = null!;
    public string? Note { get; set; }
    public List<Studente> Studenti { get; } = new List<Studente>();
}
