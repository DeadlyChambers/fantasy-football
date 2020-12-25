using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using SCC.FantasyFootball.Pages.Players;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Games
{
    public class EditModel : UpdateBasePage
    {
        private readonly IEntitiesManager<GameDto> _entitiesManager;
        private readonly IEntitiesManager<TeamDto> _teamEntitiesManager;

        public EditModel(IEntitiesManager<GameDto> entitiesManager, IEntitiesManager<TeamDto> teamEntitiesManager)
        {
            _entitiesManager = entitiesManager;
            _teamEntitiesManager = teamEntitiesManager;
        }


        [BindProperty]
        public GameDto Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Game =await _entitiesManager.GetOrDefaultAsync(id.Value);

            if (Game == null)
            {
                return NotFound();
            }
            var pagedREquest = new PagedList<TeamDto>
            {
                PageSize = 20
            };
            var aways = await _teamEntitiesManager.GetPageAsync(pagedREquest);
           ViewData["Awayteamid"] = new SelectList(aways.Items, "Id", "Name");
           ViewData["Hometeamid"] = new SelectList(aways.Items, "Id", "Name");
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

            var team = await _entitiesManager.UpdateAsync(Game);
            if (team == null)
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
