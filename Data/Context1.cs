using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sz.Models;

namespace sz.Models
{
    public class Context1 : DbContext
    {
        public Context1 (DbContextOptions<Context1> options)
            : base(options)
        {
        }

        public DbSet<sz.Models.Acessorio> Acessorio { get; set; }

        public DbSet<sz.Models.Frasco> Frasco { get; set; }

        public DbSet<sz.Models.Cliente> Cliente { get; set; }

        public DbSet<sz.Models.Endereco> Endereco { get; set; }

        public DbSet<sz.Models.OleoBase> OleoBase { get; set; }

        public DbSet<sz.Models.OleoEssencial> OleoEssencial { get; set; }


        public DbSet<sz.Models.Simulacao> Simulacao { get; set; }


        public DbSet<sz.Models.SimulOB> SimulOB { get; set; }


        public DbSet<sz.Models.SimulOE> SimulOE { get; set; }


      
    }
}
