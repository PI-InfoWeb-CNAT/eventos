using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Checkins.Models;
using W_Dev.Areas.Sessao.Models;
using System.Data.Entity;

namespace W_Dev.DAL
{
    public class CheckinDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Checkin> ObterCheckinsClassificadosPorId()
        {
            return context.Checkins.OrderBy(b => b.CheckinId);
        }
        public IQueryable<Sessão> ObterCheckinsClassificadosPorSessao()
        {
            IQueryable<Sessão> query;
            query =
            from sessão in context.Sessões
            join checkins in context.Checkins on sessão.SessãoId equals checkins.SessãoId
            select sessão;
            return query;
        }
        public IQueryable<Sessão> ObterCheckinsClassificadosPorHorarioI()
        {
            IQueryable<Sessão> query;
            query =
            from sessão in context.Sessões
            join checkins in context.Checkins on sessão.HoraInicial equals checkins.HoraInicial
            select sessão;
            return query;
        }
        public IQueryable<Sessão> ObterCheckinsClassificadosPorHorarioF()
        {
            IQueryable<Sessão> query;
            query =
            from sessão in context.Sessões
            join checkins in context.Checkins on sessão.Horafinal equals checkins.Horafinal
            select sessão;
            return query;
        }
        public Checkin ObterCheckinsPorId(long id)
        {
            return context.Checkins.Where(f => f.CheckinId == id).First();
        }
        public void GravarCheckins(Checkin checkin)
        {
            if (checkin.CheckinId == 0)
            {
            context.Checkins.Add(checkin);
            }
                else
                {
                    context.Entry(checkin).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            public Checkin EliminarCheckinsPorId(long id)
            {
                Checkin checkin = ObterCheckinsPorId(id);
                context.Checkins.Remove(checkin);
                context.SaveChanges();
                return checkin;
            }

    }
}