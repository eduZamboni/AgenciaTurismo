using System;

namespace AgenciaTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int CapacidadeMaxima { get; set; }
        public int ReservasAtuais { get; set; }

        // Evento para quando a capacidade é atingida
        public event Action<string> CapacityReached;

        public void AdicionarReserva()
        {
            ReservasAtuais++;
            if (ReservasAtuais > CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"Capacidade máxima de {CapacidadeMaxima} atingida para o pacote '{Titulo}'!");
            }
        }
    }
}
