using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_Dev.Models;
using W_Dev.Context;

namespace W_Dev.Controllers
{
    public class ProgramaçãoController : Controller
    {
        // GET: Programação
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Sessões.OrderBy(c => c.Titulo));
        }
    }
}