using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AgenciaTurismo.Pages
{
    [Authorize]
    public class ClienteDetailsModel : PageModel
    {
        public Cliente Cliente { get; set; } = new Cliente();

        private readonly AgenciaTurismoContext _context;

        public ClienteDetailsModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (cliente == null)
            {
                return NotFound();
            }

            Cliente = cliente;
            return Page();
        }
    }
}
