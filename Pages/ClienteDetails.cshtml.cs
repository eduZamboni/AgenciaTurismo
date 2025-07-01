using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages
{
    public class ClienteDetailsModel : PageModel
    {
        public Cliente Cliente { get; set; }

        public IActionResult OnGet(int id)
        {
            // Simulação: normalmente buscaria do banco de dados
            var clientesFake = new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "João Silva", Email = "joao@email.com" },
                new Cliente { Id = 2, Nome = "Maria Souza", Email = "maria@email.com" }
            };

            Cliente = clientesFake.FirstOrDefault(c => c.Id == id);

            if (Cliente == null)
                return NotFound();

            return Page();
        }
    }
}
