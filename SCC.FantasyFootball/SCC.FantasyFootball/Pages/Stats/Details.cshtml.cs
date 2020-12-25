using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class DetailsModel : PageModel
    {
        private readonly IMultiEntitiesManager<StatDto> _statManager;

        public DetailsModel(IMultiEntitiesManager<StatDto> sm)
        {
            _statManager = sm;
        }


        public StatDto Stat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? gid, int? tid, int? pid)
        {

            ///Really all three of these have to be populated
            if (gid == null)
            {
                return NotFound();
            }

            Stat = await _statManager.GetOrDefaultAsync(gid.Value, tid.Value, pid.Value);

            if (Stat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
