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
    public class IndexModel : PageModel
    {
        private readonly StandAutomoveis_1.Data.ViaturasContext _context;

        public IndexModel(StandAutomoveis_1.Data.ViaturasContext context)
        {
            _context = context;
        }

        public IList<Viatura> Viatura { get;set; } = default!;

        public SelectList Lojas { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public string LojaViatura { get; set; }

        public async Task OnGetAsync()
        {
            /*
            if (_context.Viatura != null)
            {
                Viatura = await _context.Viatura.ToListAsync();
            }
            */

            IQueryable<string> lojaQuery = from m in _context.Viatura
                                           orderby m.Loja
                                           select m.Loja;
            var viaturas = from m in _context.Viatura select m;

            if (!String.IsNullOrEmpty(LojaViatura))
            {
                viaturas = viaturas.Where(s => s.Loja == LojaViatura);
            }

            Lojas = new SelectList(await lojaQuery.Distinct().ToListAsync());
            Viatura = await viaturas.ToListAsync();
        }
    }
}
