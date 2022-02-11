using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Inscricao.Models;

namespace W_Dev.Areas.Inscricao.Controllers
{
    public class InscricaoController : Controller
    {
        // GET: Inscricao/Inscricao
        public ActionResult Index()
        {
            return View();
        }
    }
}