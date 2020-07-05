using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Domain.DTO.User
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(60, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}