using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class DeleteModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.postgresContext _context;

        public DeleteModel(SCC.FantasyFootball.DataAccess.postgresContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stat Stat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stat = await _context.Stats
                .Include(s => s.Game)
                .Include(s => s.Player)
                .Include(s => s.Team).FirstOrDefaultAsync(m => m.Gameid == id);

            if (Stat == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stat = await _context.Stats.FindAsync(id);

            if (Stat != null)
            {
                _context.Stats.Remove(Stat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
