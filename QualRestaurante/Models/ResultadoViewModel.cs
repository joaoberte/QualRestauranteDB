using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualRestaurante.Models
{
    public class ResultadoViewModel
    {
        public ResultadoViewModel() { }

        public ICollection<Restaurante> RestaurantesJaEscolhidos { get; set; }

        public Restaurante Escolhido { get; set; }
    }
}