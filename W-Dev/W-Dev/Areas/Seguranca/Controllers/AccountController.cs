using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.Infraestrutura;

namespace W_Dev.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {
        // Propriedades
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private GerenciadorUsuario UserManager
        {
            get
            {
                return
          HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.FindByEmail(details.Email);
                if (user == null )
                {
                    ModelState.AddModelError("", "E-Mail ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    { IsPersistent = false }, ident);
                    if(returnUrl == null){
                        returnUrl = "~/Areas/Eventos/Eventos/Views/Index";
                        return Redirect("~/Sessao/Sessões/Index");
                    }
                }
            }
            return View(details);
        }
    }
}