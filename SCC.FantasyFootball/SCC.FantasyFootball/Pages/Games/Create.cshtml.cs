using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Games
{
    public class CreateModel : CreateBasePage
    {
        private readonly IEntitiesManager<GameDto> _entitiesManager;
        private readonly IEntitiesManager<TeamDto> _teamEntitiesManager;

        public CreateModel(IEntitiesManager<GameDto> entitiesManager, IEntitiesManager<TeamDto> teamEntitiesManager)
        {
            _entitiesManager = entitiesManager;
            _teamEntitiesManager = teamEntitiesManager;
        }


        public async Task<IActionResult> OnGet()
        {
            var pagedREquest = new PagedList<TeamDto>
            {
                PageSize = 20
            };
            var aways = await _teamEntitiesManager.GetPageAsync(pagedREquest);
            ViewData["Awayteamid"] = new SelectList(aways.Items, "Id", "Name");
            ViewData["Hometeamid"] = new SelectList(aways.Items, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GameDto Game { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Game = await _entitiesManager.AddAsync(Game);

            return RedirectToPage("./Index");
        }
    }
}
