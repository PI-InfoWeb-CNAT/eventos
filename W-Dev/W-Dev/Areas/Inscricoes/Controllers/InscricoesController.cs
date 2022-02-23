using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Eventos.Models;
using W_Dev.Areas.Inscricoes.Models;
using W_Dev.DAL;

namespace W_Dev.Areas.Inscricoes.Controllers
{
    public class InscricoesController : Controller
    {

        InscricaoDAL inscricaoDAL = new InscricaoDAL();
        EventosDAL eventosDAL = new EventosDAL();
        UsuariosDAL dados = new UsuariosDAL();
        // GET: Inscricao/Inscricao
        private ActionResult ObterVisaoEventosPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = eventosDAL.ObterEventosPorId((long)id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }
        private ActionResult GravarInscricoes(Inscricao inscricao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inscricaoDAL.GravarInscricoes(inscricao);
                    return RedirectToAction("Insert");
                }
                return View(inscricao);
            }
            catch
            {
                return View(inscricao);
            }
        }
        [Authorize(Roles = "Organizador")]
        public ActionResult Index()
        {
            return View(inscricaoDAL.ObterInscritosClassificadoPorUsuario());
        }
        public ActionResult Lista()
        {
            return View(eventosDAL.ObterEventosClassificadosPorNome());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Inscricao inscricao)
        {
            return GravarInscricoes(inscricao);
        }
    }
}