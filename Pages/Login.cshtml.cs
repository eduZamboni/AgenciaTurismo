using AgenciaTurismo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgenciaTurismo.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Se já estiver logado, redireciona para a página inicial
            if (User.Identity?.IsAuthenticated == true)
            {
                Response.Redirect("/");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Usuário e senha são obrigatórios.";
                return Page();
            }

            var success = await _authService.LoginAsync(HttpContext, Username, Password);

            if (success)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Usuário ou senha inválidos.";
                return Page();
            }
        }
    }
} 