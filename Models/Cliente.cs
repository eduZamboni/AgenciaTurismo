using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} tem formato inválido")]
        public string Email { get; set; } = string.Empty;
        
        // Campo para exclusão lógica
        public bool IsDeleted { get; set; } = false;
        
        // Data da exclusão lógica
        public DateTime? DeletedAt { get; set; }
        
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
