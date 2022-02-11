using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Checkin.Models;
using System.Data.Entity;

namespace W_Dev.DAL
{
    public class CheckinDAL
    {
            EFContext context = new EFContext();
            public IQueryable<Checkin> ObterCheckinsPorId(long id)
            {
                return context.Checkins.Where(j => j.CheckinId == id).First();
            }
            public void GravarCheckins(Checkin checkin)
            {
                if (checkin.CheckinId is null)
                {
                    context.Inscricoes.Add(checkin);
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
                context.Sessões.Remove(checkin);
                context.SaveChanges();
                return checkin;
            }

    }
}