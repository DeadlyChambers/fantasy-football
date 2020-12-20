﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly SCC.FantasyFootball.DataAccess.FootballContext _context;

        public DetailsModel(SCC.FantasyFootball.DataAccess.FootballContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.Playerid == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
