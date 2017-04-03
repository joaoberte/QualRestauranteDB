using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QualRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualRestaurante.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            ResultadoViewModel vm = new ResultadoViewModel();

            vm.Escolhido = GetMaisVotado(DateTime.Now);

            vm.RestaurantesJaEscolhidos = ControleJaVotados();

            return View(vm);
        }

        [Authorize]
        public ActionResult Votacao()
        {
            VotacaoViewModel vm = new VotacaoViewModel();

            vm.Restaurantes = ControleNaoVotados();

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            vm.JaVotou = currentUser.JaVotou();

            return View(vm);
        }

        [Authorize]
        public ActionResult Votar(int id)
        {

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            if (currentUser.JaVotou() || ControleJaVotados().Where(r => r.Id == id).Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                Voto voto = new Voto();
                voto.RestauranteId = id;
                voto.PessoaId = User.Identity.GetUserId();
                voto.data = DateTime.Now;
                db.Votos.Add(voto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ICollection<Restaurante> ControleJaVotados()
        {
            List<Restaurante> restaurantes = new List<Restaurante>();

            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (GetMaisVotado(DateTime.Now.AddDays(-1)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-1)));
                }
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                if (GetMaisVotado(DateTime.Now.AddDays(-1)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-1)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-2)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-2)));
                }
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                if (GetMaisVotado(DateTime.Now.AddDays(-1)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-1)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-2)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-2)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-3)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-3)));
                }
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                if (GetMaisVotado(DateTime.Now.AddDays(-1)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-1)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-2)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-2)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-3)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-3)));
                }
                if (GetMaisVotado(DateTime.Now.AddDays(-4)) != null)
                {
                    restaurantes.Add(GetMaisVotado(DateTime.Now.AddDays(-4)));
                }
            }

            return restaurantes;
        }

        public ICollection<Restaurante> ControleNaoVotados()
        {
            List<Restaurante> restaurantes = db.Restaurantes.ToList();

            foreach (Restaurante r in ControleJaVotados())
            {
                restaurantes.Remove(r);
            }

            return restaurantes;
        }

        public Restaurante GetMaisVotado(DateTime data)
        {
            Restaurante maisVotado = db.Restaurantes.FirstOrDefault();

            List<Restaurante> restaurantes = db.Restaurantes.ToList();

            foreach (Restaurante r in restaurantes)
            {
                if (r.NumeroDeVotos(data) > maisVotado.NumeroDeVotos(data))
                {
                    maisVotado = r;
                }
            }

            if(maisVotado.NumeroDeVotos(data) > 0)
            {
                return maisVotado;
            }
            else
            {
                return null;
            }
        }
    }
}