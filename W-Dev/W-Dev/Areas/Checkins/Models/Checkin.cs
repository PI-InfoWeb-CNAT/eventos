using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W_Dev.Areas.Sessao.Models;

namespace W_Dev.Areas.Checkins.Models
{
    public class Checkin
    {
    public int CheckinId { get; set; }

    public int SessãoId { get; set; }

    public Sessão Sessoes { get; set; }
        
    }
}