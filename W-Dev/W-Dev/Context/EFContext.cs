using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Models;

namespace W_Dev.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Sessão> Sessões { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}