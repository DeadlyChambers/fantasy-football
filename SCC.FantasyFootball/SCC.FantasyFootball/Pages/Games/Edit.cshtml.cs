using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public EditModel(SCC.FantasyFootball.DataAccess.FootballContext context)
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
           ViewData["Awayteamid"] = new SelectList(_context.Teams, "Teamid", "Conference");
           ViewData["Hometeamid"] = new SelectList(_context.Teams, "Teamid", "Conference");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Game.Modifieddate = DateTime.Now;
            _context.Attach(Game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.Gameid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Gameid == id);
        }
    }
}
