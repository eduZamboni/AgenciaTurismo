using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class CidadeDestino
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string Pais { get; set; } = string.Empty;


    }
} 