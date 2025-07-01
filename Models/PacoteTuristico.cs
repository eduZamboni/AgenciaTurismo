using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }

        public int CapacidadeMaxima { get; set; }

        public decimal Preco { get; set; }

        public List<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; } = new List<PacoteTuristicoDestino>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Evento para quando a capacidade é atingida
        public event Action<string>? CapacityReached;

        public void AdicionarReserva()
        {
            if (Reservas == null)
                Reservas = new List<Reserva>();
            Reservas.Add(new Reserva()); // Adiciona reserva fictícia
            if (Reservas.Count > CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"Capacidade máxima de {CapacidadeMaxima} atingida para o pacote '{Titulo}'!");
            }
        }
    }
}
