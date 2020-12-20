using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Enums;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class CreateModel : PageModel
    {
        private readonly ITeamsManager _teamsManager;

        public CreateModel(ITeamsManager teamsManager)
        {
            _teamsManager = teamsManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TeamDto Team { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Team = await _teamsManager.AddAsync(Team);

            return RedirectToPage("./Index");
        }
    }
}
