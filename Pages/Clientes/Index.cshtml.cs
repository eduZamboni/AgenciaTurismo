using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismo.Models.AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismo.Models.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Filtrar apenas clientes não deletados
            Cliente = await _context.Clientes.Where(c => !c.IsDeleted).ToListAsync();
        }
    }
}
