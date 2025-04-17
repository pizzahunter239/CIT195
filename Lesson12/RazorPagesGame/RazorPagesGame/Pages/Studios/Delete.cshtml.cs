using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Data;
using RazorPagesGame.Models;

namespace RazorPagesGame.Pages.Studios
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesGame.Data.RazorPagesGameContext _context;

        public DeleteModel(RazorPagesGame.Data.RazorPagesGameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FirstOrDefaultAsync(m => m.ID == id);

            if (studio is not null)
            {
                Studio = studio;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FindAsync(id);
            if (studio != null)
            {
                Studio = studio;
                _context.Studio.Remove(Studio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
