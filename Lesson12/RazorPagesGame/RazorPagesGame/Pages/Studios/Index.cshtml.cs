using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Data;
using RazorPagesGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesGame.Pages.Studios
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public IndexModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        public IList<Studio> Studio { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Studio = await _context.Studio.Include(s => s.Games).ToListAsync();
        }
    }
}