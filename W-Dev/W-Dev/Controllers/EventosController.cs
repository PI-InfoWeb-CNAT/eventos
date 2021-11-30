using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Context;
using W_Dev.Models;
using W_Dev.DAL;

namespace W_Dev.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        private EFContext context = new EFContext();
        EventosDAL eventosDAL = new EventosDAL();
        private ActionResult ObterVisaoEventosPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Evento evento = eventosDAL.ObterEventosPorId((long)id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }
        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];
            logotipo.InputStream.Read(bytesLogotipo, 0, logotipo.ContentLength);
            return bytesLogotipo;
        }
        public FileContentResult GetLogotipo(long id)
        {
            Evento evento = eventosDAL.ObterEventosPorId(id);
            if (evento != null)
            {
                return File(evento.Logo, evento.LogotipoMimeType);
            }
            return null;
        }
        public ActionResult Index()
        {
            return View(context.Eventos.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            context.Eventos.Add(evento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = context.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                context.Entry(evento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = context.Eventos.Where(f => f.EventoId == id).First();
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = context.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Evento evento = context.Eventos.Find(id);
            context.Eventos.Remove(evento);
            context.SaveChanges();
            TempData["Message"] = "Evento " + evento.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}