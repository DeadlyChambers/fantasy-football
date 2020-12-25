using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Games
{
    public class DetailsModel : ViewBasePage
    {
        private readonly IEntitiesManager<GameDto> _entitiesManager;

        public DetailsModel(IEntitiesManager<GameDto> entitiesManager)
        {
            _entitiesManager = entitiesManager;
        }

        public GameDto Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Game = await _entitiesManager.GetOrDefaultAsync(id.Value);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
