﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Create(UsuarioViewModel model ,UsuarioDados dados)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    UserName = model.Nome,
                    Email = model.Email
                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
                    return GravarDados(dados);
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
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.
                HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                { return RedirectToAction("Index"); }
                else
                { AddErrorsFromResult(result); }
            }
            return View(uvm);
        }
    }
}