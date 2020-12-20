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
    public class DetailsModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public DetailsModel(SCC.FantasyFootball.DataAccess.FootballContext context)
        {
            _context = context;
        }

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
    }
}
