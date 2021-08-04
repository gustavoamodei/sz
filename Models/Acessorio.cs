using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    [Table("Acessorio")]
    public class Acessorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Currency)]
        
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Preco { get; set; }

        public ICollection<Simulacao> Simulacao { get; set; }

    }
}
