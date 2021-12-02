using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Models;

namespace W_Dev.DAL
{
    public class EventosDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Evento> ObterEventosClassificadosPorNome()
        {
            return context.Eventos.OrderBy(b => b.Nome);
        }
        public Evento ObterEventosPorId(long id)
        {
            return context.Eventos.Where(f => f.EventoId == id).First();
        }
        public void GravarEventos(Evento eventos)
        {
            if (eventos.EventoId == 0)
            {
                context.Eventos.Add(eventos);
            }
            else
            {
                context.Entry(eventos).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Evento EliminarEventosPorId(long id)
        {
            Evento evento = ObterEventosPorId(id);
            context.Eventos.Remove(evento);
            context.SaveChanges();
            return evento;
        }
    }
}