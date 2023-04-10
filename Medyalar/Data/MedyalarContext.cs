using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Medyalar.Models;

namespace Medyalar.Data
{
    public class MedyalarContext : DbContext
    {
        public MedyalarContext (DbContextOptions<MedyalarContext> options)
            : base(options)
        {
        }

        public DbSet<Medyalar.Models.Medya> Medya { get; set; }
    }
}
