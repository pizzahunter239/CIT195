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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesGame.Data.RazorPagesGameContext _context;

        public DetailsModel(RazorPagesGame.Data.RazorPagesGameContext context)
        {
            _context = context;
        }

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
    }
}
