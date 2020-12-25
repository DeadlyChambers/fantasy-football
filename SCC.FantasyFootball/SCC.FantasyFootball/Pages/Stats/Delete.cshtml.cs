using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class DeleteModel : UpdateBasePage
    {
        private readonly IMultiEntitiesManager<StatDto> _statManager;

        public DeleteModel(IMultiEntitiesManager<StatDto> sm)
        {   _statManager = sm;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? gid, int? tid, int? pid)
        {

            ///Really all three of these have to be populated
            if (gid == null)
            {
                return NotFound();
            }

            await _statManager.DeleteAsync(gid.Value, tid.Value, pid.Value);

            return RedirectToPage("./Index");
        }
    }
}
