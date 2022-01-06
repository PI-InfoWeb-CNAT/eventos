﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.Context;

namespace W_Dev.DAL
{
    public class UsuariosDAL
    {
            EFContext context = new EFContext();
            public IQueryable<UsuarioDados> ObterDadosClassificadosPorId()
            {
                return context.Dados.OrderBy(d => d.UsuarioDadosId);
            }
            public UsuarioDados ObterDadosPorId(long id)
            {
                return context.Dados.Where(g => g.UsuarioDadosId == id).First();
            }
        public UsuarioDados ObterDadosPorNome(string nome)
        {
            return context.Dados.Where(j => j.Nome == nome).First();
        }
        public void GravarDados(UsuarioDados dados)
            {
                if (dados.UsuarioDadosId == 0)
                {
                    context.Dados.Add(dados);
                }
                else
                {
                    context.Entry(dados).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            public UsuarioDados EliminarUsuariosPorId(long id)
            {
                UsuarioDados dados = ObterDadosPorId(id);
                context.Dados.Remove(dados);
                context.SaveChanges();
                return dados;
            }

        }

}