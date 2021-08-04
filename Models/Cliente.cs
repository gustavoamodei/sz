using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sz.Models
{
    [Table("Cliente")]
    public class Cliente
    {   
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public string Celular { get; set; }
        public string TelResidencial { get; set; }

        public ICollection<Simulacao> Simulacao { get; set; }
        public ICollection<Endereco>Endereco { get; set; }

    }
}
