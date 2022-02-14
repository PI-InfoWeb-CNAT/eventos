using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using W_Dev.Areas.Eventos.Models;
using System.Linq;
using System.Web;

namespace W_Dev.Areas.Sessao.Models
{
    public class Sessão
    {
        [DisplayName("Id")]
        public long? SessãoId { get; set; }
        [StringLength(100, ErrorMessage = "O Titulo da sessão precisa ter no mínimo 5 caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Informe o titulo da sessão")]
        public string Titulo { get; set; }
        [DisplayName("Hora de Inicio")]
        public DateTime HoraInicial { get; set; }
        [DisplayName("Hora de Termino")]
        public DateTime Horafinal { get; set; }
        [DisplayName("Local")]
        [StringLength(100, ErrorMessage = "O local da sessão precisa ter no mínimo 5 caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Informe o local da sessão")]
        public string Local { get; set; }
        public int EventoId { get; set; }
        public Evento Eventos { get; set; }

    }
}