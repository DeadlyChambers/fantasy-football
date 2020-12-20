using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class CreateModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.postgresContext _context;

        public CreateModel(SCC.FantasyFootball.DataAccess.postgresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Gameid"] = new SelectList(_context.Games, "Gameid", "Gameid");
        ViewData["Playerid"] = new SelectList(_context.Players, "Playerid", "Firstname");
        ViewData["Teamid"] = new SelectList(_context.Teams, "Teamid", "Name");
            return Page();
        }

        [BindProperty]
        public Stat Stat { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stats.Add(Stat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
