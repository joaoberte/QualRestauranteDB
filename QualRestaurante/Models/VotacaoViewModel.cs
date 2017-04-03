using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualRestaurante.Models
{
    public class VotacaoViewModel
    {
        public VotacaoViewModel() { }

        public ICollection<Restaurante> Restaurantes { get; set; }

        public ICollection<Restaurante> RestaurantesJaEscolhidos { get; set; }

        public ICollection<ApplicationUser> Usuarios { get; set; }

        public bool JaVotou { get; set; }
    }
}