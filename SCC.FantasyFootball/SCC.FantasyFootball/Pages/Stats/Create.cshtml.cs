using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Stats
{
    public class CreateModel : PageModel
    {
        private readonly IEntitiesManager<PlayerDto> _playerManager;
        private readonly IEntitiesManager<GameDto> _gameManager;
        private readonly IEntitiesManager<TeamDto> _teamManager;
        private readonly IMultiEntitiesManager<StatDto> _statManager;

        public CreateModel(IEntitiesManager<PlayerDto> pm, IEntitiesManager<GameDto> gm, IEntitiesManager<TeamDto> tm, IMultiEntitiesManager<StatDto> sm)
        {
            _playerManager = pm;
            _gameManager = gm;
            _teamManager = tm;
            _statManager = sm;
        }

        public async Task<IActionResult> OnGet()
        {
            var teams = await _teamManager.GetPageAsync(new PagedList<TeamDto>
            {
                PageSize = 20
            });
            var games = await _gameManager.GetPageAsync(new PagedList<GameDto>
            {
                PageSize = 20
            });
            var players = await _playerManager.GetPageAsync(new PagedList<PlayerDto>
            {
                PageSize = 20
            });
            //These Ids might acyually have to map to Stats properies
            ViewData["Gameid"] = new SelectList(games.Items, "Id", "Gameid");
        ViewData["Playerid"] = new SelectList(players.Items, "Id", "Firstname");
        ViewData["Teamid"] = new SelectList(teams.Items, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StatDto Stat { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Stat = await _statManager.AddAsync(Stat);

            return RedirectToPage("./Index");
        }
    }
}
