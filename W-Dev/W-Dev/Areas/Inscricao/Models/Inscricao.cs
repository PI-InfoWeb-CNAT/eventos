using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Areas.Eventos.Models;

namespace W_Dev.Areas.Inscricao.Models
{
    public class Inscricao
    {
        public int InscricaoId { get; set; }
        public int EventoId { get; set; }
        public Evento Eventos { get; set; }
    }
}