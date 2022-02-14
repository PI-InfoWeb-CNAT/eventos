using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Inscricao.Models;
using W_Dev.Areas.Eventos.Models;
using W_Dev.Context;
using W_Dev.DAL;

namespace W_Dev.Areas.Inscricao.Controllers
{
    public class InscricaoController : Controller
    {

        InscricaoDAL inscricaoDAL = new InscricaoDAL();
        EventosDAL eventosDAL = new EventosDAL();
        // GET: Inscricao/Inscricao
        [Authorize(Roles = "Aluno")]
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
        [Authorize(Roles = "Organizador")]
        public ActionResult Index()
        {
            return View(eventosDAL.ObterEventosClassificadosPorNome());
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult Insert(long? id)
        {
            return ObterVisaoEventosPorId(id);
        }
    }
}