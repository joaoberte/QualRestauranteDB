using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QualRestaurante.Models
{
    public class Restaurante
    {
        public Restaurante() { }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public int NumeroDeVotos(DateTime data)
        {
            return Votos.Where(v => v.data.Date == data.Date).Count();
        }
    }
}