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
    public class FilmesLocadosController : Controller
    {
        // GET: FilmesLocados
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();

            List<FilmesLocados> alugados = contexto.Alugados.ToList();

            return View(alugados);

        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmesLocados filmesLocados)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Alugados.Add(filmesLocados);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmesLocados);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            FilmesLocados filmes = contexto.Alugados.Find(id);

            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            FilmesLocados filmes = contexto.Alugados.Find(id);

            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmesLocados filmes)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(filmes).State = System.Data.Entity.EntityState.Modified;

                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmes);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();
            FilmesLocados filmes = contexto.Alugados.Find(id);

            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            FilmesLocados filmes = contexto.Alugados.Find(id);

            contexto.Alugados.Remove(filmes);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Lista()
        {
            MeuContexto contexto = new MeuContexto();
            List<FilmesLocados> lista = contexto.Alugados.ToList();

            return View(lista);
        }

        public ActionResult Promocoes()
        {
            return View();
        }

        public ActionResult BuscarLocados()
        {
            Session["lista"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult BuscarLocados(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var clie = contexto.Alugados.Where(c => c.NomeCliente.ToLower().Equals(nome.ToLower()));

            List<FilmesLocados> lista = clie.ToList();
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
