using MoveLocadora.Models;
using MoveLocadora.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MoveLocadora.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();

            List<Cliente> clientes = contexto.Clientes.ToList();

            return View(clientes);
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Cliente cli = contexto.Clientes.Find(id);

            if (cli == null)
            {
                return HttpNotFound();
            }
            return View(cli);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Cliente cli = contexto.Clientes.Find(id);

            if (cli == null)
            {
                return HttpNotFound();
            }
            return View(cli);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(cli).State = System.Data.Entity.EntityState.Modified;

                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cli);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Cliente cli = contexto.Clientes.Find(id);

            if (cli == null)
            {
                return HttpNotFound();
            }
            return View(cli);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Cliente cli = contexto.Clientes.Find(id);

            contexto.Clientes.Remove(cli);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Lista()
        {
            MeuContexto contexto = new MeuContexto();
            List<Cliente> lista = contexto.Clientes.ToList();

            return View(lista);
        }
        public ActionResult BuscaPorNome()
        {
            Session["lista"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult BuscarNome(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var serie = contexto.Clientes.Where(c => c.Nome.ToLower().Equals(nome.ToLower()));

            List<Cliente> lista = serie.ToList();
            ViewBag.Lista = lista;
            if (lista.Count > 0)
            {
                Session["lista"] = serie;
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