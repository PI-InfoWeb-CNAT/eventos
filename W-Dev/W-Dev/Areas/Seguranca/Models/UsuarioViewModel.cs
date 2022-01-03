using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W_Dev.Areas.Seguranca.Models
{
    public class UsuarioViewModel
    {
        public string UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string CPF { get; set; }
        //public UsuarioDados Dados { get; set; }
        //public virtual ICollection<UsuarioDados> Dados { get; set; }
    }
}