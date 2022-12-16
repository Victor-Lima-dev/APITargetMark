
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APITargetMark.Models;


public class Empresa
{
    public int EmpresaId { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string Nome { get; set; }
   
    public IEnumerable<Campanha> Campanhas { get; set; }
}
