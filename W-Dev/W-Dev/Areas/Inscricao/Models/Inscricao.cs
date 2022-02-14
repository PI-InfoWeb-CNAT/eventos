﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Areas.Eventos.Models;
using W_Dev.Areas.Seguranca.Models;

namespace W_Dev.Areas.Inscricao.Models
{
    public class Inscricao
    {
        public int InscricaoId { get; set; }
        public string UsuarioDadosId { get; set; }
        public int EventoId { get; set; }
        public Evento Eventos { get; set; }
        public UsuarioDados Dados { get; set; }
    }
}