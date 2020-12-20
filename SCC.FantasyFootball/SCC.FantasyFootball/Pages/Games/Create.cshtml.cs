using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public CreateModel(SCC.FantasyFootball.DataAccess.FootballContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Awayteamid"] = new SelectList(_context.Teams, "Teamid", "Name");
        ViewData["Hometeamid"] = new SelectList(_context.Teams, "Teamid", "Name");
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Game.Createddate = DateTime.Now;
            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
