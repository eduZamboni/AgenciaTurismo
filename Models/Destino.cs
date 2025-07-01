using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Destino
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Nome { get; set; }

        [Required, MinLength(2)]
        public string Pais { get; set; }

        public List<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; }
    }
}
