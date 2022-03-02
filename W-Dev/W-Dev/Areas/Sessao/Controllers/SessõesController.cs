using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Context;
using W_Dev.Areas.Sessao.Models;
using W_Dev.DAL;

namespace W_Dev.Areas.Sessao.Controllers
{
    public class SessõesController : Controller
    {
        // GET: Sessões
        private EFContext context = new EFContext();
        EventosDAL eventosDal = new EventosDAL();
        SessoesDAL sessoesDal = new SessoesDAL();
        // GET: Fabricantes
        private ActionResult ObterVisaoSessoesPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Sessão sessão = sessoesDal.ObterSessoesPorId((long)id);
            if (sessão == null)
            {
                return HttpNotFound();
            }
            return View(sessão);
        }
        private void PopularViewBag(Sessão sessão = null)
        {
            if (sessão == null)
            {
                ViewBag.EventoId = new SelectList(eventosDal.ObterEventosClassificadosPorNome(),
                "EventoId", "Nome");
            }
            else
            {
                ViewBag.EventoId = new SelectList(eventosDal.ObterEventosClassificadosPorNome(),
               "EventoId", "Nome", sessão.EventoId);
            }
        }
        private ActionResult GravarSessoes(Sessão sessão)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sessoesDal.GravarSessoes(sessão);
                    return RedirectToAction("Index");
                }
                PopularViewBag(sessão);
                return View(sessão);
            }
            catch
            {
                PopularViewBag(sessão);
                return View(sessão);
            }
        }
        [Authorize(Roles = "Organizador")]
        public ActionResult Index()
        {
            return View(context.Sessões.OrderBy(c => c.Titulo));
        }

        // GET: Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sessão sessão)
        {
            return GravarSessoes(sessão);
        }
        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(sessoesDal.ObterSessoesPorId((long)id));
            return ObterVisaoSessoesPorId(id);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sessão sessão)
        {
            return GravarSessoes(sessão);
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessão sessão = context.Sessões.Where(f => f.SessãoId == id).First();
            if (sessão == null)
            {
                return HttpNotFound();
            }
            return View(sessão);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessão sessão = context.Sessões.Find(id);
            if (sessão == null)
            {
                return HttpNotFound();
            }
            return View(sessão);
        }
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Sessão sessão = context.Sessões.Find(id);
            context.Sessões.Remove(sessão);
            context.SaveChanges();
            TempData["Message"] = "Sessão " + sessão.Titulo.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }
    }
}