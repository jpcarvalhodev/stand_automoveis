using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StandAutomoveis_1.Models;

namespace StandAutomoveis_1.Data
{
    public class ViaturasContext : DbContext
    {
        public ViaturasContext (DbContextOptions<ViaturasContext> options)
            : base(options)
        {
        }

        public DbSet<StandAutomoveis_1.Models.Viatura> Viatura { get; set; } = default!;
    }
}
