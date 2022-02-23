using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Context;
using W_Dev.Areas.Certificados.Models;
using System.Data.Entity;

namespace W_Dev.DAL
{
    public class CertificadoDAL
    {
        EFContext context = new EFContext();
        public IQueryable<Certificado> ObterCertificadosClassificadosPorIdade()
        {
            return context.Certificados.OrderBy(b => b.Certificadoid);
        }
        public Certificado ObterCertificadosPorId(long id)
        {
            return context.Certificados.Where(f => f.Certificadoid == id).First();
        }
        public void GravarCertificados(Certificado certificado)
        {
            if (certificado.Certificadoid == 0)
            {
                context.Certificados.Add(certificado);
            }
            else
            {
                context.Entry(certificado).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Certificado EliminarSessoesPorId(long id)
        {
            Certificado certificado = ObterCertificadosPorId(id);
            context.Certificados.Remove(certificado);
            context.SaveChanges();
            return certificado;
        }
    }
}