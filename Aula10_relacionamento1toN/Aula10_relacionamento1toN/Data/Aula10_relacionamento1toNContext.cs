using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula10_relacionamento1toN.Models;

namespace Aula10_relacionamento1toN.Data
{
    public class Aula10_relacionamento1toNContext : DbContext
    {
        public Aula10_relacionamento1toNContext (DbContextOptions<Aula10_relacionamento1toNContext> options)
            : base(options)
        {
        }

        public DbSet<Aula10_relacionamento1toN.Models.Afiliado> Afiliado { get; set; }

        public DbSet<Aula10_relacionamento1toN.Models.Dependente> Dependente { get; set; }
    }
}
