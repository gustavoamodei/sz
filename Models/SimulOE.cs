using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    public class SimulOE
    {
        public int Id { get; set; }
        public int SimulacaoId { get; set; }
        public int OleoEssencialId { get; set; }
        public int GotasOE { get; set; }
        public OleoEssencial  OleoEssencial { get; set; }
    }
}
