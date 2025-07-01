using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages
{
    public class CreateClienteModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        public string Mensagem { get; set; }

        public void OnGet()
        {
            Cliente = new Cliente();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Mensagem = "Por favor, corrija os erros abaixo.";
                return Page();
            }

            // Aqui você pode salvar o cliente no banco de dados futuramente
            Mensagem = $"Cliente '{Cliente.Nome}' cadastrado com sucesso!";
            ModelState.Clear();
            Cliente = new Cliente();
            return Page();
        }
    }
}
