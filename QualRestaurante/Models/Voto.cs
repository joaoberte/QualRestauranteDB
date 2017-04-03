using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QualRestaurante.Models
{
    public class Voto
    {
        public Voto() { }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime data { get; set; }

        public virtual ApplicationUser Pessoa { get; set; }

        [Required]
        public string PessoaId { get; set; }

        public virtual Restaurante Restaurante { get; set; }

        [Required]
        public int RestauranteId { get; set; }
    }
}