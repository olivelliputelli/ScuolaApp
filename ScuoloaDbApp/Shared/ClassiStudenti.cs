using System.ComponentModel.DataAnnotations;

namespace ScuoloaDbApp.Shared;

public partial class ClassiStudenti
{
    [Key]
    [StringLength(5)]
    public string Sigla { get; set; } = null!;

    [StringLength(255)]
    public string Ubicazione { get; set; } = null!;

    [StringLength(255)]
    public string? Note { get; set; }

    public int? NumeroStudenti { get; set; }
}
