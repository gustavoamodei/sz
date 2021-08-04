using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    [Table("Frasco")]
    public class Frasco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public  string Descricao{ get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Preco { get; set; }

       
    }
}
