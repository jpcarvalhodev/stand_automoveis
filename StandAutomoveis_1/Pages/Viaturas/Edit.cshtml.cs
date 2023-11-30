using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandAutomoveis_1.Data;
using StandAutomoveis_1.Models;

namespace StandAutomoveis_1.Pages.Viaturas
{
    public class EditModel : PageModel
    {
        private readonly StandAutomoveis_1.Data.ViaturasContext _context;

        public EditModel(StandAutomoveis_1.Data.ViaturasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Viatura Viatura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Viatura == null)
            {
                return NotFound();
            }

            var viatura =  await _context.Viatura.FirstOrDefaultAsync(m => m.Id == id);
            if (viatura == null)
            {
                return NotFound();
            }
            Viatura = viatura;
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

            _context.Attach(Viatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViaturaExists(Viatura.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ViaturaExists(int id)
        {
          return (_context.Viatura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
