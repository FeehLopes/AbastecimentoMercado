using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Filme fi = contexto.Filmes.Find(id);

            if (fi == null)
            {
                return HttpNotFound();
            }
            return View(fi);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Filme fi = contexto.Filmes.Find(id);

            if (fi == null)
            {
                return HttpNotFound();
            }
            return View(fi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Filme fi)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(fi).State = System.Data.Entity.EntityState.Modified;

                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fi);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Filme fi = contexto.Filmes.Find(id);

            if (fi == null)
            {
                return HttpNotFound();
            }
            return View(fi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Filme fi = contexto.Filmes.Find(id);

            contexto.Filmes.Remove(fi);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

       public ActionResult Filmes()
        {
            return View();
        }
        public ActionResult FilmesAcervo()
        {
            return View();
        }
        public ActionResult FilmesProximosLancamentos()

        {
            return View();
        }
        public ActionResult BuscarFilme()
        {
            Session["lista"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult BuscarFilme(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var clie = contexto.Filmes.Where(c => c.Titulo.ToLower().Equals(nome.ToLower()));

            List<Filme> lista = clie.ToList();
            ViewBag.Lista = lista;
            if (lista.Count > 0)
            {
                Session["lista"] = clie;
            }
            else
            {
                Session["lista"] = null;
                ViewBag.Message = "Nada encontrado no sistema para: " + nome;
            }

            return View();
        }
    }
}
