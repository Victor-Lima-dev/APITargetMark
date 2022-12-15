
using System.ComponentModel.DataAnnotations;

namespace APITargetMark.Models;


public class Empresa
{
    public int EmpresaId { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string Nome { get; set; }
}
