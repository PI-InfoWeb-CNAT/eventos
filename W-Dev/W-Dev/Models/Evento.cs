using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W_Dev.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public string Instagram { get; set; }
        public string LogotipoMimeType { get; set; }
        public byte[] Logo { get; set; }
        public string BannerMimeType { get; set; }
        public byte[] Banner { get; set; }
        public TimeSpan Dias { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string NomeArquivoLogo { get; set; }
        public long TamanhoArquivoLogo { get; set; }
        public string NomeArquivoBanner { get; set; }
        public long TamanhoArquivoBanner { get; set; }


    }
}