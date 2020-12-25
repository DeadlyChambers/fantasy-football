using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly IEntitiesManager<PlayerDto> _playersManager;

        public DeleteModel(IEntitiesManager<PlayerDto> playersManager)
        {
            _playersManager = playersManager;
        }


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _playersManager.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
