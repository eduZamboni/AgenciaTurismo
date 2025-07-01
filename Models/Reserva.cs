using System;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = new PacoteTuristico();

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataReserva { get; set; }


    }
}
