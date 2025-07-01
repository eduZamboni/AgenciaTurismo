using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Models;
using System;
using System.Collections.Generic;

namespace AgenciaTurismo.Pages
{
    public class PacoteEventoModel : PageModel
    {
        [BindProperty]
        public int CapacidadeMaxima { get; set; } = 3;

        [BindProperty]
        public int ReservasParaAdicionar { get; set; } = 1;

        public string Log { get; set; } = string.Empty;

        public void OnGet() { }

        public void OnPost()
        {
            var pacote = new PacoteTuristico
            {
                Titulo = "Pacote Teste",
                CapacidadeMaxima = CapacidadeMaxima,
                Reservas = new List<Reserva>()
            };

            // Assina o evento para logar no console e exibir na página
            pacote.CapacityReached += (msg) =>
            {
                Console.WriteLine(msg);
                Log = msg;
            };

            for (int i = 0; i < ReservasParaAdicionar; i++)
            {
                pacote.AdicionarReserva();
            }

            if (string.IsNullOrEmpty(Log))
                Log = $"Reservas adicionadas: {ReservasParaAdicionar}. Capacidade máxima: {CapacidadeMaxima}.";
        }
    }
}
