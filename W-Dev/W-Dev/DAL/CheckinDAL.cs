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
        public IQueryable<Checkin> ObterCheckinsClassificadosPorId()
        {
            return context.Checkins.OrderBy(b => b.CheckinId);
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