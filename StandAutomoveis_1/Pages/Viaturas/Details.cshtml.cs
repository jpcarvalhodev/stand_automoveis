using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StandAutomoveis_1.Data;
using StandAutomoveis_1.Models;

namespace StandAutomoveis_1.Pages.Viaturas
{
    public class DetailsModel : PageModel
    {
        private readonly StandAutomoveis_1.Data.ViaturasContext _context;

        public DetailsModel(StandAutomoveis_1.Data.ViaturasContext context)
        {
            _context = context;
        }

      public Viatura Viatura { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Viatura == null)
            {
                return NotFound();
            }

            var viatura = await _context.Viatura.FirstOrDefaultAsync(m => m.Id == id);
            if (viatura == null)
            {
                return NotFound();
            }
            else 
            {
                Viatura = viatura;
            }
            return Page();
        }
    }
}
