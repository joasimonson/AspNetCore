using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}