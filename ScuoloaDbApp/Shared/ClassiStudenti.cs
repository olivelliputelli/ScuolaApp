using System.ComponentModel.DataAnnotations;
namespace ScuoloaDbApp.Shared;
public class ClassiStudenti
{
    [Key]
    public string Sigla { get; set; } = null!;
    public string Ubicazione { get; set; } = null!;
    public string? Note { get; set; }
    public int? NumeroStudenti { get; set; }
}
