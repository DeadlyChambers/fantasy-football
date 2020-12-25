using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class EditModel : UpdateBasePage
    {
        private readonly IMultiEntitiesManager<StatDto> _statManager;

        public EditModel(IMultiEntitiesManager<StatDto> sm)
        {
            _statManager = sm;
        }

        [BindProperty]
        public StatDto Stat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? gameId, int? teamId, int? playerId)
        {
            if (gameId == null || teamId == null || playerId == null)
            {
                return NotFound();
            }

            Stat = await _statManager.GetOrDefaultAsync(gameId.Value, teamId.Value, playerId.Value);
            if (Stat == null)
            {
                return NotFound();
            }
            ViewData["Gameid"] = new SelectList(new List<KeyValuePair<string, string>>{ Stat.Game.AsKeyValuePair() }, "key", "value");
            ViewData["Playerid"] = new SelectList(new List<KeyValuePair<string, string>>{ Stat.Player.AsKeyValuePair() }, "key", "value");
            ViewData["Teamid"] = new SelectList(new List<KeyValuePair<string, string>>{ Stat.Team.AsKeyValuePair() }, "key", "value");
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

            var stat = await _statManager.UpdateAsync(Stat);
            if (stat == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
