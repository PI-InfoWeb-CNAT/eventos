using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Inscricao.Models;
using System.Data.Entity;

namespace W_Dev.DAL
{
    public class IscricaoDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Inscricao> ObterInscricoesPorId(long id)
        {
            return context.Inscricoes.Where(j => j.InscricaoId == id).First();
        }
        public void GravarInscricoes(Inscricao inscricao)
        {
            if (inscricao.InscricaoId is null)
            {
                context.Inscricoes.Add(inscricao);
            }
            else
            {
                context.Entry(inscricao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Inscricao EliminarInscricoesPorId(long id)
        {
            Inscricao inscricao = ObterInscricaosPorId(id);
            context.Sessões.Remove(inscricao);
            context.SaveChanges();
            return inscricao;
        }

    }
}