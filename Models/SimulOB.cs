using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    public class SimulOB
    {
        public int Id { get; set; }
        public int SimulacaoId { get; set; }
        public int OleoBaseId { get; set; }
        public int Ml { get; set; }
        public OleoBase OleoBase { get; set; }
    }
}
