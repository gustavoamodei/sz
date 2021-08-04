using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        public int Id { get; set; }
        [MaxLength(9)] 
        [MinLength(8)]
        public string Cep { get; set; }

         [Required]
         [MaxLength(2)]
         [MinLength(2)]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        public string Rua { get; set; }
     
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
