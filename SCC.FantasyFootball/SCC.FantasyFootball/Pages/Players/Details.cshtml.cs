using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly IEntitiesManager<PlayerDto> _playersManager;

        public DetailsModel(IEntitiesManager<PlayerDto> playersManager)
        {
            _playersManager = playersManager;
        }
        public PlayerDto Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _playersManager.GetOrDefaultAsync(id.Value);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
