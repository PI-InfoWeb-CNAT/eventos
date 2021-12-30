using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Areas.Eventos.Models;
using W_Dev.Areas.Sessao.Models;
using W_Dev.Areas.Seguranca.Models;


namespace W_Dev.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Sessão> Sessões { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<UsuarioDados> Dados { get; set; } 
    }
}