using System.ComponentModel.DataAnnotations;

namespace APITargetMark.Models
{
    public class UsuarioDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string ConfirmarSenha { get; set; }
    }
}
