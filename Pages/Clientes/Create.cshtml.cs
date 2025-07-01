using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages.Clientes
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismo.Models.AgenciaTurismoContext _context;

        public CreateModel(AgenciaTurismo.Models.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync chamado!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido!");
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            Console.WriteLine("Cliente salvo!");

            return RedirectToPage("./Index");
        }
    }
}
