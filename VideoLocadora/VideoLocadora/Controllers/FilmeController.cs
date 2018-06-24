using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLocadora.Models;
using VideoLocadora.Models.DAL;

namespace VideoLocadora.Controllers
{
    public class FilmeController : Controller
    {
        // GET: Filme
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();

            List<Filme> filmes = contexto.Filmes.ToList();

            return View(filmes);
          
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Filmes.Add(filme);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);

        }
        public ActionResult Lista()
        {
            MeuContexto contexto = new MeuContexto();
            List<Filme> lista = contexto.Filmes.ToList();

            return View(lista);
        }
    }
}