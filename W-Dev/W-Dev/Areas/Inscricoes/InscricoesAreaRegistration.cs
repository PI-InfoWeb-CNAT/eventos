using System.Web.Mvc;

namespace W_Dev.Areas.Inscricoes
{
    public class InscricoesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Inscricoes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Inscricoes_default",
                "Inscricoes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}