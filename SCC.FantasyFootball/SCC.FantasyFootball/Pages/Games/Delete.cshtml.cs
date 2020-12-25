using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;

namespace SCC.FantasyFootball.Pages.Games
{
    public class DeleteModel : UpdateBasePage
    {
        private readonly IEntitiesManager<GameDto> _entitiesManager;

        public DeleteModel(IEntitiesManager<GameDto> entitiesManager)
        {
            _entitiesManager = entitiesManager;
        }


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _entitiesManager.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
