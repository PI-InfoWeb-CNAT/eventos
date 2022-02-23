using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using System.Data.Entity;
using W_Dev.Areas.Inscricoes.Models;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.Areas.Eventos.Models;

namespace W_Dev.DAL
{
    public class InscricaoDAL
    {   
        EFContext context = new EFContext();
        public IQueryable<Inscricao> ObterIncricoesClassificadosPorId()
        {
            return context.Inscricoes.OrderBy(b => b.InscricaoId);
        }
        public IQueryable<UsuarioDados> ObterInscritosClassificadoPorUsuario()
        {
            //return context.Dados.Select
            IQueryable <UsuarioDados> query; 
            query =  
            from dado in context.Dados
            join inscricao in context.Inscricoes on dado.UsuarioDadosId equals inscricao.UsuarioDadosId
            //where dado.UsuarioDadosId == id
            select dado;
            return query;
        }
        public IQueryable<Evento> ObterInscritosClassificadosPorEventos()
        {
            IQueryable<Evento> query;
            query =
            from evento in context.Eventos
            join inscricao in context.Inscricoes on evento.EventoId equals inscricao.EventoId
            select evento;
            return query;
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