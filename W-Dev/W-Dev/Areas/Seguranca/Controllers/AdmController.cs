using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.DAL;
using W_Dev.Infraestrutura;

namespace W_Dev.Areas.Seguranca.Controllers
{
    public class AdmController : Controller
    {
        UsuariosDAL usuariosDAL = new UsuariosDAL();
        // Definição da Propriedade GerenciadorUsuario
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
        [Authorize]
        private ActionResult GravarDados(UsuarioDados dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuariosDAL.GravarDados(dados);
                    return RedirectToAction("Index");
                }
                return View(dados);
            }
            catch
            {
                return View(dados);
            }
        }
        // GET: Seguranca/Admin
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
        public ActionResult Create()
        {
            return View();
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    UserName = model.Nome,
                    Email = model.Email
                };
                UsuarioDados usuario = new UsuarioDados
                {
                    CPF = model.CPF,
                    Matricula = model.Matricula,
                    Nome = model.Nome
                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                {
                    GravarDados(usuario);
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            // inicia o objeto usuário para visão
            var uvm = new UsuarioViewModel();
            uvm.UsuarioId = usuario.Id;
            uvm.Nome = usuario.UserName;
            uvm.Email = usuario.Email;
            UsuarioDados usuarioDados = usuariosDAL.ObterDadosPorNome(uvm.Nome);
            uvm.Matricula = usuarioDados.Matricula;
            uvm.CPF = usuarioDados.CPF;
            return View(uvm);
        }
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = GerenciadorUsuario.FindById(uvm.UsuarioId);
                usuario.UserName = uvm.Nome;
                usuario.Email = uvm.Email;
                UsuarioDados usuarioDados = usuariosDAL.ObterDadosPorNome(uvm.Nome);
                usuarioDados.Matricula = uvm.Matricula;
                usuarioDados.CPF = uvm.CPF;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.
                HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                {
                    GravarDados(usuarioDados);
                    return RedirectToAction("Index");
                }
                else
                { AddErrorsFromResult(result); }
            }
            return View(uvm);
        }
        public ActionResult Delete(string id, string nome)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            UsuarioDados usuarioDados = usuariosDAL.ObterDadosPorNome(nome);
            if (usuario == null && usuarioDados == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Delete(Usuario usuario, UsuarioDados usuarioDados)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            UsuarioDados dados = usuariosDAL.ObterDadosPorNome(usuarioDados.Nome);
            if (user != null && dados != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    try
                    {
                        UsuarioDados usuarioDadoss = usuariosDAL.EliminarUsuariosPorId(dados.UsuarioDadosId);
                        TempData["Message"] = "Usuario " + usuarioDadoss.Nome.ToUpper() + " foi removido";
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
        }
    }
}