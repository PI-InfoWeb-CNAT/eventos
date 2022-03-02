using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Sessao.Models;
using W_Dev.Areas.Checkins.Models;
using W_Dev.DAL;

namespace W_Dev.Areas.Checkins.Controllers
{
    public class CheckinController : Controller
    {
        CheckinDAL checkinDAL = new CheckinDAL();
        SessoesDAL sessoesDAL = new SessoesDAL();
        // GET: Checkin/Checkin
        private ActionResult ObterVisaoSessõesPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessão sessão = sessoesDAL.ObterSessoesPorId((long)id);
            if (sessão == null)
            {
                return HttpNotFound();
            }
            return View(sessão);
        }
        private ActionResult GravarCheckins(Checkin checkin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    checkinDAL.GravarCheckins(checkin);
                    return RedirectToAction("Insert");
                }
                return View(checkin);
            }
            catch
            {
                return View(checkin);
            }
        }
        public ActionResult Index()
        {
            return View(sessoesDAL.ObterSessoesClassificadosPorTitulo());
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult Insert()
        {
            return View(sessoesDAL.ObterSessoesClassificadosPorTitulo());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Checkin checkin)
        {
            return GravarCheckins(checkin);
        }
    }
}