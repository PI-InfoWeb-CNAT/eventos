using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_Dev.Infraestrutura;

namespace W_Dev.Areas.Seguranca.Controllers
{
    public class AdmController : Controller
    {
        // Definição da Propriedade GerenciadorUsuario
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();

            }
        }
        // GET: Seguranca/Admin
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
    }
}