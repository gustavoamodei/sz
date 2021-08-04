using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    public class OleoEssencial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ml { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public Decimal Valor_Compra { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Preco_Gota { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

       

    }
}
