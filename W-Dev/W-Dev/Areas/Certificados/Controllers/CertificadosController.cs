using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_Dev.Areas.Certificados.Models;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.Areas.Sessao.Models;
using W_Dev.Areas.Checkins.Models;
using W_Dev.DAL;

namespace W_Dev.Areas.Certificados.Controllers
{
    public class CertificadosController : Controller
    {
        CertificadoDAL certificadoDAL = new CertificadoDAL();
        UsuariosDAL usuariosDAL = new UsuariosDAL();
        CheckinDAL checkinDAL = new CheckinDAL();
        EventosDAL eventosDAL = new EventosDAL();
        InscricaoDAL inscricaoDAL = new InscricaoDAL();
        private byte[] SetLogo(HttpPostedFileBase logo)
        {
            var bytesLogo = new byte[logo.ContentLength];
            logo.InputStream.Read(bytesLogo, 0, logo.ContentLength);
            return bytesLogo;
        }
        public FileContentResult GetCert(long id)
        {
            Certificado certificado = certificadoDAL.ObterCertificadosPorId(id);
            if (certificado != null)
            {
                return File(certificado.Cert, certificado.CertMimeType);
            }
            return null;
        }
        public ActionResult DownloadArquivo(long id)
        {
            Certificado certificado = certificadoDAL.ObterCertificadosPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath(
            "~/App_Data/" + certificado.NomeArquivoCert), FileMode.Create,
            FileAccess.Write);
            fileStream.Write(certificado.Cert, 0,
            Convert.ToInt32(certificado.TamanhoArquivoCert));
            fileStream.Close();
            return File(fileStream.Name, certificado.CertMimeType, certificado.NomeArquivoCert);
        }
        private ActionResult GravarCertificados(Certificado certificado, HttpPostedFileBase cert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cert != null)
                    {
                        certificado.CertMimeType = cert.ContentType;
                        certificado.Cert = SetLogo(cert);
                        certificado.NomeArquivoCert = cert.FileName;
                        certificado.TamanhoArquivoCert = cert.ContentLength;
                    }
                    certificadoDAL.GravarCertificados(certificado);
                    return RedirectToAction("Index");
                }
                return View(certificado);
            }
            catch
            {
                return View(certificado);
            }
        }
        /*private ActionResult GravarHorario(Checkin checkin)
        {
            var hi = checkinDAL.ObterCheckinsClassificadosPorHorarioI();
            var hf = checkinDAL.ObterCheckinsClassificadosPorHorarioF();
        }*/
        // GET: Certificados/Certificados
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(Certificado certificado, HttpPostedFileBase cert)
        {
            return GravarCertificados(certificado, cert);
        }
        public ActionResult Details()
        {
            return View(inscricaoDAL.ObterInscritosClassificadosPorEventos());
        }
        public ActionResult Present(UsuarioDados dados, Checkin checkin)
        {
            Certificado certificado = new Certificado();
            certificado.CPF = dados.CPF;
            certificado.Nome = dados.Nome;
            var h1 = checkin.HoraInicial;
            var h2 = checkin.Horafinal;
            TimeSpan horas = h2.Subtract(h1);
            certificado.Horas = horas;

            return View(certificado);
        }

    }
}