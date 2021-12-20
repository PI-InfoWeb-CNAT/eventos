using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W_Dev.Areas.Eventos.Models
{
    public class Evento
    {
        [DisplayName("Id")]
        public int EventoId { get; set; }
        [StringLength(100, ErrorMessage = "O nome do evento precisa ter no mínimo 5 caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Informe o nome do evento")]
        public string Nome { get; set; }
        public string Instagram { get; set; }
        public string LogoMimeType { get; set; }
        public byte[] Logo { get; set; }
        public string BannerMimeType { get; set; }
        public byte[] Banner { get; set; }
        public int Dias { get; set; }
        [DisplayName("Inicio")]
        public DateTime DataInicial { get; set; }
        [DisplayName("Final")]
        public DateTime DataFinal { get; set; }
        public string NomeArquivoLogo { get; set; }
        public long TamanhoArquivoLogo { get; set; }
        public string NomeArquivoBanner { get; set; }
        public long TamanhoArquivoBanner { get; set; }


    }
}