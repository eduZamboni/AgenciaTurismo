using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgenciaTurismo.Pages
{
    public class CreateCidadeDestinoModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;
        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = new CidadeDestino();
        [TempData]
        public string Mensagem { get; set; } = string.Empty;

        public CreateCidadeDestinoModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CidadesDestino.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            Mensagem = "Cidade de destino cadastrada com sucesso!";

            return RedirectToPage("/Index");
        }
    }
} 