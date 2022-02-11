using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Sessao.Models;

namespace W_Dev.DAL
{
    public class SessoesDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Sessão> ObterSessoesClassificadosPorTitulo()
        {
            return context.Sessões.OrderBy(b => b.Titulo);
        }
        public Sessão ObterSessoesPorId(long id)
        {
            return context.Sessões.Where(f => f.SessãoId == id).First();
        }
        public void GravarSessoes(Sessão sessão)
        {
            if (sessão.SessãoId is null)
            {
                context.Sessões.Add(sessão);
            }
            else
            {
                context.Entry(sessão).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Sessão EliminarSessoesPorId(long id)
        {
            Sessão sessão = ObterSessoesPorId(id);
            context.Sessões.Remove(sessão);
            context.SaveChanges();
            return sessão;
        }

    }
}