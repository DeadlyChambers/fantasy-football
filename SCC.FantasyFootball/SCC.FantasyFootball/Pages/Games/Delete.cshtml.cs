using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public DeleteModel(SCC.FantasyFootball.DataAccess.FootballContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games
                .Include(g => g.Awayteam)
                .Include(g => g.Hometeam).FirstOrDefaultAsync(m => m.Gameid == id);

            if (Game == null)
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

            Game = await _context.Games.FindAsync(id);

            if (Game != null)
            {
                _context.Games.Remove(Game);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
