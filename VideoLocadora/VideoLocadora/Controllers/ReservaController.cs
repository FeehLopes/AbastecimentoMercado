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
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();

            List<Reserva> reservas = contexto.Reservas.ToList();

            return View(reservas);
           
        }
        public ActionResult Create()
        {
            return View();

        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Reservas.Add(reserva);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Reserva res = contexto.Reservas.Find(id);

            if (res == null)
            {
                return HttpNotFound();
            }
            return View(res);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Reserva res = contexto.Reservas.Find(id);

            if (res == null)
            {
                return HttpNotFound();
            }
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reserva res)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(res).State = System.Data.Entity.EntityState.Modified;

                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(res);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Reserva res = contexto.Reservas.Find(id);

            if (res == null)
            {
                return HttpNotFound();
            }
            return View(res);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Reserva res = contexto.Reservas.Find(id);

            contexto.Reservas.Remove(res);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Lista()
        {
            MeuContexto contexto = new MeuContexto();
            List<Reserva> lista = contexto.Reservas.ToList();

            return View(lista);
        }

        public ActionResult BuscarReservas()
        {
            Session["lista"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult BuscarReservas(string nome)
        {
            MeuContexto contexto = new MeuContexto();
            var clie = contexto.Reservas.Where(c => c.NomeCliente.ToLower().Equals(nome.ToLower()));

            List<Reserva> lista = clie.ToList();
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
