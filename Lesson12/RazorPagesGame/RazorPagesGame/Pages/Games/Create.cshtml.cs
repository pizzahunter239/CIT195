using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesGame.Data;
using RazorPagesGame.Models;
using System.Threading.Tasks;

namespace RazorPagesGame.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public CreateModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudioID"] = new SelectList(_context.Studio, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["StudioID"] = new SelectList(_context.Studio, "ID", "Name");
                return Page();
            }

            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}