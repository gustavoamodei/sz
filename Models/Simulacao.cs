using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    [Table("Simulacao")]
    public class Simulacao
    {
        public int Id { get; set; }
        public int FrascoId { get; set; }
        public int AcessorioId { get; set; }

        public int ClienteId { get; set; }
        

        public string NomeSimulacao { get; set; }

        public float Ml_por_cento { get; set; }
        public int Ml_oleo_essencial { get; set; }

        public int Lucro { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco_Parcial { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Margem_lucro { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public Frasco Frasco { get; set; }
        public Acessorio Acessorio { get; set; }

        public ICollection<OleoBase>OleoBase { get; set; }
        public ICollection<SimulOB> SimulOB  { get; set; }
        public ICollection<OleoEssencial> OleoEssencial { get; set; }
        public ICollection<SimulOE> SimulOE { get; set; }



    }
}
