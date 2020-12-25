using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.PagePolicy;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class EditModel : UpdateBasePage
    {
        //TODO get rid of the context reference
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public EditModel(SCC.FantasyFootball.DataAccess.FootballContext context)
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
           ViewData["Gameid"] = new SelectList(_context.Games, "Gameid", "Gameid");
           ViewData["Playerid"] = new SelectList(_context.Players, "Playerid", "Firstname");
           ViewData["Teamid"] = new SelectList(_context.Teams, "Teamid", "Conference");
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

            _context.Attach(Stat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(Stat.Gameid))
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

        private bool StatExists(int id)
        {
            return _context.Stats.Any(e => e.Gameid == id);
        }
    }
}
