using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCC.FantasyFootball.Common.Enums;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.postgresContext _context;
        public PlayerGameStatus PlayerGameStatus { get; set; }
        public PlayerStatus PlayerStatus { get;set; }


        public CreateModel(SCC.FantasyFootball.DataAccess.postgresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Player.Createddate = DateTime.Now;

            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
