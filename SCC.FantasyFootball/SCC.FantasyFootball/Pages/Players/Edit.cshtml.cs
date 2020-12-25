using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Areas.Identity.Data;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;


namespace SCC.FantasyFootball.Pages.Players
{
   
    public class EditModel : UpdateBasePage
    {
        private readonly IEntitiesManager<PlayerDto> _playersManager;

        public EditModel(IEntitiesManager<PlayerDto> playersManager)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var player = await _playersManager.UpdateAsync(Player);
            if (player == null)
                return NotFound();

            return RedirectToPage("./Index");
        }

    }
}
