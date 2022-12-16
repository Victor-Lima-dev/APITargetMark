using System.ComponentModel.DataAnnotations;

namespace APITargetMark.Models
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Titulo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Texto { get; set; }
        //public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
    }
}
