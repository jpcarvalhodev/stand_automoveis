using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StandAutomoveis_1.Data;
using StandAutomoveis_1.Models;

namespace StandAutomoveis_1.Pages.Viaturas
{
    public class CreateModel : PageModel
    {
        private readonly StandAutomoveis_1.Data.ViaturasContext _context;

        public CreateModel(StandAutomoveis_1.Data.ViaturasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Viatura Viatura { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Viatura == null || Viatura == null)
            {
                return Page();
            }

            _context.Viatura.Add(Viatura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
