using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Service;

namespace AgenciaTurismo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string? Mensagem { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnPostCriarReserva()
    {
        // Exemplo de dados fictícios
        string cliente = "João";
        string pacote = "Férias no Caribe";
        string mensagem = $"Reserva criada para o cliente {cliente} no pacote '{pacote}'.";

        Action<string> logAction = LoggerService.LogToConsole;
        logAction += LoggerService.LogToFile;
        logAction += LoggerService.LogToMemory;

        logAction(mensagem);
        Mensagem = "Reserva criada e log registrada!";
    }
}
