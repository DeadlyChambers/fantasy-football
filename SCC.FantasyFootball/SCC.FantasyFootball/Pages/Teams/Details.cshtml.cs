using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.Common.Extensions;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.postgresContext _context;

        public DetailsModel(SCC.FantasyFootball.DataAccess.postgresContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams.FirstOrDefaultAsync(m => m.Teamid == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
