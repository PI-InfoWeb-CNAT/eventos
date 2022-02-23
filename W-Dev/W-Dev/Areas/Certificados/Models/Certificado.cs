using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Areas.Sessao.Models;
using W_Dev.Areas.Seguranca.Models;


namespace W_Dev.Areas.Certificados.Models
{
    public class Certificado
    {
        public int Certificadoid { get; set; } 
        public int Horas { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime Horafinal { get; set; }
        public string CertMimeType { get; set; }
        public byte[] Cert { get; set; }
        public string NomeArquivoCert { get; set; }
        public long TamanhoArquivoCert { get; set; }
        public Sessão Sessoes { get; set; }
        public UsuarioDados Dados { get; set; }
    }
}