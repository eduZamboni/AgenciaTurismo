using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Service;

namespace AgenciaTurismo.Pages
{
    public class ReservaTotalModel : PageModel
    {
        [BindProperty]
        public int NumeroDiarias { get; set; }

        [BindProperty]
        public decimal ValorDiaria { get; set; }

        public decimal? Total { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            if (NumeroDiarias > 0 && ValorDiaria > 0)
            {
                Total = ReservaService.CalcularTotal(NumeroDiarias, ValorDiaria);
            }
        }
    }
}
