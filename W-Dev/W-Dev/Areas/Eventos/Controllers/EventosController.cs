using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Context;
using W_Dev.Areas.Eventos.Models;
using W_Dev.DAL;
using System.IO;

namespace W_Dev.Areas.Eventos.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        //private EFContext context = new EFContext();
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
        private byte[] SetLogo(HttpPostedFileBase logo)
        {
            var bytesLogo = new byte[logo.ContentLength];
            logo.InputStream.Read(bytesLogo, 0, logo.ContentLength);
            return bytesLogo;
        }
        private byte[] SetBanner(HttpPostedFileBase banner)
        {
            var bytesBanner = new byte[banner.ContentLength];
            banner.InputStream.Read(bytesBanner, 0, banner.ContentLength);
            return bytesBanner;
        }
        public ActionResult DownloadArquivo(long id)
        {
            Evento evento = eventosDAL.ObterEventosPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath(
            "~/App_Data/" + evento.NomeArquivoLogo), FileMode.Create,
            FileAccess.Write);
            fileStream.Write(evento.Logo, 0,
            Convert.ToInt32(evento.TamanhoArquivoLogo));
            fileStream.Close();
            return File(fileStream.Name, evento.LogoMimeType, evento.NomeArquivoLogo);
        }
        public FileContentResult GetLogo(long id)
        {
            Evento evento = eventosDAL.ObterEventosPorId(id);
            if (evento != null)
            {
                return File(evento.Logo, evento.LogoMimeType);
            }
            return null;
        }
        public FileContentResult GetBanner(long id)
        {
            Evento evento = eventosDAL.ObterEventosPorId(id);
            if (evento != null)
            {
                return File(evento.Banner, evento.BannerMimeType);
            }
            return null;
        }
        //private ActionResult GravarEventos(Evento evento, HttpPostedFileBase logotipo, string chkRemoverImagem)
        private ActionResult GravarEventos(Evento evento, HttpPostedFileBase logo, HttpPostedFileBase banner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (chkRemoverImagem != null)
                    //{
                    //    evento.Logo = null;
                    //}
                    if (logo != null)
                    {
                        evento.LogoMimeType = logo.ContentType;
                        evento.Logo = SetLogo(logo);
                        evento.NomeArquivoLogo = logo.FileName;
                        evento.TamanhoArquivoLogo = logo.ContentLength;
                    }
                    if (banner != null)
                    {
                        evento.BannerMimeType = banner.ContentType;
                        evento.Banner = SetBanner(banner);
                        evento.NomeArquivoBanner = banner.FileName;
                        evento.TamanhoArquivoBanner = banner.ContentLength;
                    }
                    eventosDAL.GravarEventos(evento);
                    return RedirectToAction("Index");
                }
                return View(evento);
            }
            catch
            {
                return View(evento);
            }
        }
        public ActionResult Index()
        {
            return View(eventosDAL.ObterEventosClassificadosPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento, HttpPostedFileBase logo = null, HttpPostedFileBase banner = null)
        {
            return GravarEventos(evento, logo, banner);
        }
        /*public ActionResult Create(Evento evento)
        {
            context.Eventos.Add(evento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }*/
        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterVisaoEventosPorId(id);
        }
        /*{
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
        }*/

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento, HttpPostedFileBase logotipo = null, HttpPostedFileBase banner = null)
        {
            return GravarEventos(evento, logotipo, banner);
        }
        /*public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                context.Entry(evento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }*/
        public ActionResult Details(long? id)
        {
            return ObterVisaoEventosPorId(id);
        }
        /*{
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
        }*/

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoEventosPorId(id);
        }
        /*{
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
        }*/
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Evento evento = eventosDAL.EliminarEventosPorId(id);
                TempData["Message"] = "Evento " + evento.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /*public ActionResult Delete(long id)
        {
            Evento evento = context.Eventos.Find(id);
            context.Eventos.Remove(evento);
            context.SaveChanges();
            TempData["Message"] = "Evento " + evento.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }*/

    } 
}