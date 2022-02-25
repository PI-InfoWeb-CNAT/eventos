using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Areas.Sessao.Models;
using W_Dev.Areas.Seguranca.Models;
using W_Dev.Areas.Eventos.Models;


namespace W_Dev.Areas.Certificados.Models
{
    public class Certificado
    {
        public int Certificadoid { get; set; }
        public int EventoId { get; set; }
        public int SessãoId { get; set; }
        public TimeSpan Horas { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string CertMimeType { get; set; }
        public byte[] Cert { get; set; }
        public string NomeArquivoCert { get; set; }
        public long TamanhoArquivoCert { get; set; }
        public string Texto { get; set; }
        public Evento Eventos { get; set; }
        public UsuarioDados Dados { get; set; }
    }
}