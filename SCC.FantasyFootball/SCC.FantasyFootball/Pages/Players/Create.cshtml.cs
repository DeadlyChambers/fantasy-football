using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly IEntitiesManager<PlayerDto> _playersManager;

        public CreateModel(IEntitiesManager<PlayerDto> playersManager)
        {
            _playersManager = playersManager;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlayerDto Player { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Player = await _playersManager.AddAsync(Player);

            return RedirectToPage("./Index");
        }
    }
}
