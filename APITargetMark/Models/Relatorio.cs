using System.ComponentModel.DataAnnotations;

namespace APITargetMark.Models
{
    public class Relatorio
    {
        public int RelatorioId { get; set; }
        //obrigatorio e limite de caracteres
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Titulo { get; set; }
        public int MensagensVisualizadas { get; set; }
        public int MensagensInteragidas { get; set; }
        public int TaxaConversao { get; set; }
        public int CampanhaId { get; set; }
        
    }
}
