using System.ComponentModel.DataAnnotations;
namespace ScuoloaDbApp.Shared;
public partial class Classe
{
    [Key]
    [StringLength(5)]
    public string Sigla { get; set; } = null!;

    [StringLength(255)]
    public string Ubicazione { get; set; } = null!;

    [StringLength(255)]
    public string? Note { get; set; }

    public virtual ICollection<Studente> Studenti { get; } = new List<Studente>();
}
