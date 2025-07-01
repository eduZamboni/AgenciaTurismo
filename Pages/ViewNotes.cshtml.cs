using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace AgenciaTurismo.Pages
{
    public class ViewNotesModel : PageModel
    {
        [BindProperty]
        public string NoteTitle { get; set; } = string.Empty;
        [BindProperty]
        public string NoteContent { get; set; } = string.Empty;
        public List<string?> Notes { get; set; } = new();
        public string SelectedNoteContent { get; set; } = string.Empty;
        public string SelectedNote { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;

        private string FilesDir =>
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        public void OnGet(string note = "")
        {
            if (!Directory.Exists(FilesDir))
                Directory.CreateDirectory(FilesDir);

            Notes = Directory.GetFiles(FilesDir, "*.txt")
                .Select(Path.GetFileName)
                .ToList() ?? new List<string>();

            if (!string.IsNullOrEmpty(note))
            {
                var filePath = Path.Combine(FilesDir, note);
                if (System.IO.File.Exists(filePath))
                {
                    SelectedNote = note;
                    SelectedNoteContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NoteTitle) || string.IsNullOrWhiteSpace(NoteContent))
            {
                Mensagem = "Título e conteúdo são obrigatórios.";
                OnGet();
                return Page();
            }

            if (!Directory.Exists(FilesDir))
                Directory.CreateDirectory(FilesDir);

            var safeTitle = string.Join("_", NoteTitle.Split(Path.GetInvalidFileNameChars()));
            var fileName = $"{safeTitle}.txt";
            var filePath = Path.Combine(FilesDir, fileName);

            System.IO.File.WriteAllText(filePath, NoteContent);

            Mensagem = $"Nota '{NoteTitle}' criada!";
            NoteTitle = "";
            NoteContent = "";
            OnGet();
            return Page();
        }
    }
}
