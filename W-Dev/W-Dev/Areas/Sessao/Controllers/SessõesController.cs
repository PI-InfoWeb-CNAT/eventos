using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Context;
using W_Dev.Areas.Sessao.Models;

namespace W_Dev.Areas.Sessao.Controllers
{
    public class SessõesController : Controller
    {
        // GET: Sessões
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Sessões.OrderBy(c => c.Titulo));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sessão sessão)
        {
            context.Sessões.Add(sessão);
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
            Sessão sessão = context.Sessões.Find(id);
            if (sessão == null)
            {
                return HttpNotFound();
            }
            return View(sessão);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sessão sessão)
        {
            if (ModelState.IsValid)
            {
                context.Entry(sessão).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessão);
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