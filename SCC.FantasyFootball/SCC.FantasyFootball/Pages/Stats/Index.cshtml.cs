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
    public class IndexModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.postgresContext _context;

        public IndexModel(SCC.FantasyFootball.DataAccess.postgresContext context)
        {
            _context = context;
        }

        public IList<Stat> Stat { get;set; }

        public async Task OnGetAsync()
        {
            Stat = await _context.Stats
                .Include(s => s.Game)
                .Include(s => s.Player)
                .Include(s => s.Team).ToListAsync();
        }
    }
}
