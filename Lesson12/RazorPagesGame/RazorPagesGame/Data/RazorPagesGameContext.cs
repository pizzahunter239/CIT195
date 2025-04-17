using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Models;

namespace RazorPagesGame.Data
{
    public class RazorPagesGameContext : DbContext
    {
        public RazorPagesGameContext (DbContextOptions<RazorPagesGameContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesGame.Models.Game> Game { get; set; } = default!;
        public DbSet<RazorPagesGame.Models.Studio> Studio { get; set; } = default!;
    }
}
