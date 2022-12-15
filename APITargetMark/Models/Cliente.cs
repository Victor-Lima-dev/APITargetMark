using System.ComponentModel.DataAnnotations;

namespace APITargetMark.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required]
        //limitar caracteres
        [StringLength(15, MinimumLength = 5)]
        public string Nome { get; set; }
        //limitar valor, maximo 100
        [Range(0, 100)]
        public int Idade { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Genero { get; set; }
        [Required]
        //limitar caracteres, minimo 6 maximo 12
        [StringLength(12, MinimumLength = 2)]
        public string Regiao { get; set; }
    }
}
