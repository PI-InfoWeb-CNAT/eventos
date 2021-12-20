using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using W_Dev.Areas.Seguranca.Models;

namespace W_Dev.DAL
{
    //(public class IdentityDbContext
    //{
        public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
        {
            public IdentityDbContextAplicacao() : base("IdentityDb")
            { }
            static IdentityDbContextAplicacao()
            {
                Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit());
            }
            public static IdentityDbContextAplicacao Create()
            {
                return new IdentityDbContextAplicacao();
            }

        }
        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
        {
        }
}