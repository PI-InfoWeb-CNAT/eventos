using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Inscricao.Models;
using System.Data.Entity;

namespace W_Dev.DAL
{
    public class InscricaoDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Inscricao> ObterIncricoesClassificadosPorId()
        {
            return context.Inscricoes.OrderBy(b => b.InscricaoId);
        }
        public Inscricao ObterInscricoesPorId(long id)
        {
            return context.Inscricoes.Where(f => f.InscricaoId == id).First();
        }
        public void GravarInscricoes(Inscricao inscricao)
        {
            if (inscricao.InscricaoId == 0)
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
            Inscricao inscricao = ObterInscricoesPorId(id);
            context.Inscricoes.Remove(inscricao);
            context.SaveChanges();
            return inscricao;
        }

    }
}