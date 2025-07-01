using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Service;

namespace AgenciaTurismo.Pages
{
    public class DescontoModel : PageModel
    {
        [BindProperty]
        public decimal? ValorOriginal { get; set; }

        public decimal? ValorComDesconto { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ValorOriginal.HasValue)
            {
                CalculateDelegate calc = DescontoHelper.AplicarDesconto;
                ValorComDesconto = calc(ValorOriginal.Value);
            }
        }
    }
}
