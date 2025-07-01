using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgenciaTurismo.Pages
{
    public class CreateClienteModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;
        public Cliente Cliente { get; set; } = new Cliente();
        [TempData]
        public string Mensagem { get; set; } = string.Empty;

        public CreateClienteModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            Mensagem = "Cliente cadastrado com sucesso!";

            return RedirectToPage("/Index");
        }
    }
}
