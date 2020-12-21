using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly IEntitiesManager<TeamDto> _teamsManager;
        public EditModel(IEntitiesManager<TeamDto> teamsManager)
        {
            _teamsManager = teamsManager;
        }


        [BindProperty]
        public TeamDto Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _teamsManager.GetOrDefaultAsync(id.Value);

            if (Team == null)
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

            var team = await _teamsManager.UpdateAsync(Team);
            if (team == null)
                return NotFound();
            return RedirectToPage("./Index");
        }
    }
}
