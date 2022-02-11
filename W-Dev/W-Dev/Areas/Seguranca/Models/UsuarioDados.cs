using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W_Dev.Areas.Seguranca.Models
{
    public class UsuarioDados
    {
        public int UsuarioDadosId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        /*public string Email { get; set; }
        [Required]
        public string Senha { get; set; }*/
        public string Matricula { get; set; }
        [Required]
        public string CPF { get; set; }
        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }
        // public UsuarioViewModel Usuario { get; set; }
        // public string UsuarioId { get; set; }
        //public virtual ICollection<UsuarioViewModel> Usuario { get; set; }
    }
}