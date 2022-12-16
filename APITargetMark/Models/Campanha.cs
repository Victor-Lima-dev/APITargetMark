using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APITargetMark.Models
{
    public class Campanha
    {
        public int CampanhaId { get; set; }
        //obrigatorio e limite de caracteres
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Nome { get; set; }
        //obrigatorio e limite de caracteres
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Descricao { get; set; }
        public IEnumerable<Mensagem>? Mensagem { get; set; }
        public IEnumerable<Cliente>? Clientes { get; set; }
        public int QuantidadeMensagens { get; set; }
        public DateTime Data { get; set; }
        //obrigatorio e limite de caracteres
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string PublicoAlvo { get; set; }
        public Empresa? Empresa { get; set; }
        //public int EmpresaId { get; set; }



    }
}
