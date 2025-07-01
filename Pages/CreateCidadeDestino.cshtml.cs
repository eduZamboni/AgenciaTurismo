using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages
{
    public class CreateCidadeDestinoModel : PageModel
    {
        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; }

        public string Mensagem { get; set; }

        public void OnGet()
        {
            CidadeDestino = new CidadeDestino();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Mensagem = "Por favor, corrija os erros abaixo.";
                return Page();
            }

            Mensagem = $"Cidade '{CidadeDestino.Nome}' ({CidadeDestino.Pais}) cadastrada com sucesso!";
            ModelState.Clear();
            CidadeDestino = new CidadeDestino();
            return Page();
        }
    }
} 